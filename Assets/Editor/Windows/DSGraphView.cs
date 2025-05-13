using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;


namespace DS.Windows
{
    using Data.Save;
    using Data.Error;
    using Elements;
    using Enumerations;
    using Utilities;

    public class DSGraphView : GraphView
    {
        private DSEditorWindow editorWindow;
        private DSSearchWindow searchWindow;

        private SerializableDictionary<string, DSNodeErrorData> ungroupdedNodes;
        private SerializableDictionary<string, DSGroupErrorData> groups;
        private SerializableDictionary<Group, SerializableDictionary<string, DSNodeErrorData>> groupedNodes;

        private int nameErrorsAmount;
        public int NameErrorAmount
        {
            get
            {
                return nameErrorsAmount;
            }
            
            set
            {
                nameErrorsAmount = value;

                if(nameErrorsAmount == 0)
                {
                    editorWindow.EnableSaving();
                }

                if(nameErrorsAmount == 1)
                {
                    editorWindow.DisableSaving();

                }
                Debug.Log("errores " + nameErrorsAmount);
            }

        }

        public DSGraphView(DSEditorWindow dSEditorWindow)
        {
            editorWindow = dSEditorWindow;

            //inicializar variables de diccionarios
            ungroupdedNodes = new SerializableDictionary<string, DSNodeErrorData>();
            groups = new SerializableDictionary<string, DSGroupErrorData>();
            groupedNodes = new SerializableDictionary<Group, SerializableDictionary<string, DSNodeErrorData>>();
            //Para poder manipular la ventana de los diálogos
            AddManipulators();
            AddGridBackground();
            AddSearchWindow();
            //CreateNode();
            OnElementsDeleted();
            OnGroupElementsAdded();
            OnGroupElementsRemoved();
            OnGroupRenamed();

            OnGraphViewChanged();

            AddStyles();
        }

        #region Overrided Methods
        public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
        {
            List<Port> compatiblePorts = new List<Port>();

            ports.ForEach(port =>
            {
                if (startPort == port)
                {
                    return;
                }

                if (startPort.node == port.node)
                {
                    return;
                }

                if (startPort.direction == port.direction)
                {
                    return;
                }
                compatiblePorts.Add(port);
            });

            return compatiblePorts;
        }
        #endregion

        #region Manipuladores
        private void AddManipulators()
        {
            SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);

            this.AddManipulator(new ContentDragger());
            this.AddManipulator(new SelectionDragger());
            this.AddManipulator(new RectangleSelector());

            this.AddManipulator(CreateNodeContextualMenu("Añadir nodo (Opción Simple)", DSDialogueType.SingleChoice));
            this.AddManipulator(CreateNodeContextualMenu("Añadir nodo (Opción Múltiple)", DSDialogueType.MultipleChoice));

            this.AddManipulator(CreateGroupContextualMenu());

        }
        private IManipulator CreateNodeContextualMenu(string actionTitle, DSDialogueType dialogueType)
        {
            ContextualMenuManipulator contextualMenuManipulator = new ContextualMenuManipulator(
                menuEvent => menuEvent.menu.AppendAction(actionTitle, actionEvent => AddElement(CreateNode("NombreDelDialogo", dialogueType, GetLocalMousePosition(actionEvent.eventInfo.localMousePosition))))
                );

            return contextualMenuManipulator;
        }


        private IManipulator CreateGroupContextualMenu()
        {
            ContextualMenuManipulator contextualMenuManipulator = new ContextualMenuManipulator(
            menuEvent => menuEvent.menu.AppendAction("Añadir grupo", actionEvent => CreateGroup("GrupoDeDialogos", GetLocalMousePosition(actionEvent.eventInfo.localMousePosition)))
            );

            return contextualMenuManipulator;
        }


        #endregion

        #region Creación de Elementos
        public DSGroup CreateGroup(string title, Vector2 position)
        {
            DSGroup group = new DSGroup(title, position);
            AddGroup(group);

            AddElement(group);

            foreach(GraphElement selectedElement in selection)
            {
                if(!(selectedElement is DSNode))
                {
                    continue;
                }

                DSNode node = (DSNode)selectedElement;
                group.AddElement(node);
            }

            return group;
        }

        public DSNode CreateNode(string nodeName, DSDialogueType dialogueType, Vector2 position, bool shouldDraw = true)
        {
            Type nodeType = Type.GetType($"DS.Elements.DS{dialogueType}Node");
            DSNode node = (DSNode) Activator.CreateInstance(nodeType);

            node.Initialize(nodeName, this, position);

            if (shouldDraw)
            { 
                node.Draw(); 
            }

            AddUngroupedNode(node);

            return node;
        }
        #endregion

        #region Callbacks
        public void OnElementsDeleted()
        {

            deleteSelection = (operationName, AskUser) =>
            {

                Type groupType = typeof(DSGroup);
                Type edgeType = typeof(Edge);

                List<DSGroup> groupsToDelete = new List<DSGroup>();
                List<Edge> edgesToDelete = new List<Edge>();
                List<DSNode> nodesToDelete = new List<DSNode>();

                foreach(GraphElement element in selection)
                {
                    if(element is DSNode node)
                    {
                        nodesToDelete.Add(node);

                        continue;
                    }

                    if(element.GetType() == edgeType)
                    {
                        Edge edge = (Edge)element;
                        edgesToDelete.Add(edge);
                        continue;
                    }

                    if(element.GetType() != groupType)
                    {

                        continue;
                    }

                    DSGroup group = (DSGroup)element;

                    groupsToDelete.Add(group);
                }

                foreach(DSGroup group in groupsToDelete)
                {
                    List<DSNode> groupNodes = new List<DSNode>();

                    foreach(GraphElement groupElement in group.containedElements)
                    {
                        if(!(groupElement is DSNode))
                        {
                            continue;
                        }

                        DSNode groupNode = (DSNode)groupElement;
                        groupNodes.Add(groupNode);
                    }

                    group.RemoveElements(groupNodes);
                    RemoveGroup(group);

                    RemoveElement(group);
                }

                DeleteElements(edgesToDelete);

                foreach(DSNode node in nodesToDelete)
                {
                    if(node.Group != null)
                    {
                        node.Group.RemoveElement(node);

                    }

                    RemoveUngroupdedNode(node);

                    node.DisconnectAllPorts();

                    RemoveElement(node);
                }

            };
        }

        public void OnGroupElementsAdded()
        {
            elementsAddedToGroup = (group, elements) =>
            {
                foreach(GraphElement element in elements)
                {
                    if(!(element is DSNode))
                    {
                        continue;
                    }
                    DSGroup nodeGroup = (DSGroup) group;
                    DSNode node = (DSNode)element;
                    

                    RemoveUngroupdedNode(node);
                    AddGroupedNode(node, nodeGroup);
                }
            };
        }

        public void OnGroupElementsRemoved()
        {
            elementsRemovedFromGroup = (group, elements) =>
            {
                foreach (GraphElement element in elements)
                {
                    if (!(element is DSNode))
                    {
                        continue;
                    }
                    DSNode node = (DSNode)element;

                    //remover nodo del grupo
                    RemoveGroupedNode(node, group);
                    AddUngroupedNode(node);


                }
            };
        }

        public void OnGroupRenamed()
        {
            groupTitleChanged = (group, newTitle) =>
            {

                DSGroup dSGroup = (DSGroup)group;

                dSGroup.title = newTitle.RemoveWhitespaces().RemoveSpecialCharacters();

                if (string.IsNullOrEmpty(dSGroup.title))
                {
                    if (!string.IsNullOrEmpty(dSGroup.OldTitle))
                    {
                        ++NameErrorAmount;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(dSGroup.OldTitle))
                        {
                            --NameErrorAmount;
                        }
                    }
                }

                RemoveGroup(dSGroup);

                dSGroup.OldTitle = dSGroup.title;

                AddGroup(dSGroup);
            };
        }

        private void OnGraphViewChanged()
        {
            graphViewChanged = (changes) => { 
                if(changes.edgesToCreate != null)
                {
                    foreach(Edge edge in changes.edgesToCreate)
                    {
                        DSNode nextNode = (DSNode)edge.input.node;

                        DSChoiceSaveData choiceData = (DSChoiceSaveData)edge.output.userData;
                        choiceData.NodeID = nextNode.ID;

                    }
                }

                if(changes.elementsToRemove != null)
                {
                    Type edgeType = typeof(Edge);

                    foreach(GraphElement element in changes.elementsToRemove)
                    {
                        if(element.GetType() != edgeType)
                        {
                            continue;
                        }

                        Edge edge = (Edge)element;
                        DSChoiceSaveData choiceData = (DSChoiceSaveData)edge.output.userData;
                        choiceData.NodeID = "";
                    }
                }
                return changes;
            };
        }

        #endregion

        #region Elementos repetidos
        public void AddGroup(DSGroup group)
        {
            //cambiado de title a oldtitle
            string groupName = group.title.ToLower();

            if (!groups.ContainsKey(groupName))
            {
                DSGroupErrorData groupErrorData = new DSGroupErrorData();
                groupErrorData.Groups.Add(group);

                groups.Add(groupName, groupErrorData);

                return;
            }

            List<DSGroup> groupsList = groups[groupName].Groups;
            groupsList.Add(group);

            Color errorColor = groups[groupName].ErrorData.Color;
            group.SetErrorStyle(errorColor);

            if (groupsList.Count == 2)
            {
                ++NameErrorAmount;
                groupsList[0].SetErrorStyle(errorColor);
            }


        }

        public void AddUngroupedNode(DSNode node)
        {
            string nodeName = node.DialogueName.ToLower();

            if(!ungroupdedNodes.ContainsKey(nodeName))
            {
                DSNodeErrorData nodeErrorData = new DSNodeErrorData();

                nodeErrorData.Nodes.Add(node);
                ungroupdedNodes.Add(nodeName, nodeErrorData);

                return;
            }

            List<DSNode> ungroupedNodesList = ungroupdedNodes[nodeName].Nodes;

            ungroupedNodesList.Add(node);

            Color errorColor = ungroupdedNodes[nodeName].ErrorData.Color;

            node.SetErrorStyle(errorColor);

            if(ungroupedNodesList.Count == 2)
            {
                ++NameErrorAmount;

                ungroupedNodesList[0].SetErrorStyle(errorColor);
            }

        }

        public void RemoveUngroupdedNode(DSNode node)
        {

            string nodeName = node.DialogueName.ToLower();
            List<DSNode> ungroupedNodesList = ungroupdedNodes[nodeName].Nodes;

            ungroupedNodesList.Remove(node);

            node.ResetStyle();

            if (ungroupedNodesList.Count == 1)
            {
                --NameErrorAmount;
                ungroupedNodesList[0].ResetStyle();
                return;
            }

            if(ungroupedNodesList.Count == 0)
            {
                ungroupdedNodes.Remove(nodeName);
            }
        }

        public void AddGroupedNode(DSNode node, DSGroup group)
        {
            string nodeName = node.DialogueName.ToLower();

            node.Group = group;

            if(!groupedNodes.ContainsKey(group))
            {
                groupedNodes.Add(group, new SerializableDictionary<string, DSNodeErrorData>());
            }

            if(!groupedNodes[group].ContainsKey(nodeName))
            {
                DSNodeErrorData nodeErrorData = new DSNodeErrorData();
                nodeErrorData.Nodes.Add(node);

                groupedNodes[group].Add(nodeName, nodeErrorData);
                return;
            }

            List<DSNode> groupedNodesList = groupedNodes[group][nodeName].Nodes;

            groupedNodesList.Add(node);

            Color errorColor = groupedNodes[group][nodeName].ErrorData.Color;
            
            node.SetErrorStyle(errorColor);

            if(groupedNodesList.Count == 2)
            {
                ++NameErrorAmount;
                groupedNodesList[0].SetErrorStyle(errorColor);
            }

        }

        public void RemoveGroupedNode(DSNode node, Group group)
        {
            string nodeName = node.DialogueName.ToLower();

            node.Group = null;

            List<DSNode> groupedNodesList = groupedNodes[group][nodeName].Nodes;

            groupedNodesList.Remove(node);

            node.ResetStyle();

            if (groupedNodesList.Count == 1)
            {
                --NameErrorAmount;
                groupedNodesList[0].ResetStyle();
                return;
            }

            if (groupedNodesList.Count == 0)
            {
                groupedNodes[group].Remove(nodeName);

                if (groupedNodes[group].Count == 0)
                {
                    groupedNodes.Remove(group);
                }


            }

        }

        public void RemoveGroup(DSGroup group)
        {
            string oldGroupName = group.OldTitle.ToLower();

            List<DSGroup> groupsList = groups[oldGroupName].Groups;

            groupsList.Remove(group);

            group.ResetStyle();

            if (groupsList.Count == 1)
            {
                --NameErrorAmount;
                groupsList[0].ResetStyle();

                return;
            }

            if (groupsList.Count == 0)
            {
                groups.Remove(oldGroupName);
            }

        }

        #endregion

        #region Agregar estilo a los elementos

        private void AddSearchWindow()
        {
            if(searchWindow == null)
            {
                searchWindow = ScriptableObject.CreateInstance<DSSearchWindow>();
                searchWindow.Initialize(this);
            }

            nodeCreationRequest = context => SearchWindow.Open(new SearchWindowContext(context.screenMousePosition), searchWindow);
        }
        private void AddGridBackground()
        {
            GridBackground gridBackground = new GridBackground();

            gridBackground.StretchToParentSize();
            Insert(0, gridBackground);

        }

        private void AddStyles()
        {
            this.AddStyleSheets(
                "DialogSystem/DSGraphViewStyles.uss", 
                "DialogSystem/DSNodeStyle.uss");
        }
        #endregion

        #region Utilidades

        public Vector2 GetLocalMousePosition(Vector2 mousePosition, bool isSearchWindow = false)
        {
            Vector2 worldMousePosition = mousePosition;
            
            if(isSearchWindow)
            {
                worldMousePosition -= editorWindow.position.position;
            }

            Vector2 localMousePosition = contentViewContainer.WorldToLocal(worldMousePosition);
            return localMousePosition;
        }


        public void ClearGraph()
        {
            graphElements.ForEach(graphElement => RemoveElement(graphElement));

            groups.Clear();
            groupedNodes.Clear();
            ungroupdedNodes.Clear();

            NameErrorAmount = 0;

        }
        #endregion
    }
}
