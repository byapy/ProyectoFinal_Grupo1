using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.Experimental.GraphView;


namespace DS.Elements
{
    using Data.Save;
    using System;
    using Enumerations;
    using Utilities;
    using Windows;
    public class DSMultipleChoiceNode : DSNode
    {

        public override void Initialize(string nodeName, DSGraphView dSGraphView, Vector2 position)
        {
            base.Initialize(nodeName, dSGraphView, position);

            DialogueType = DSDialogueType.MultipleChoice;

            DSChoiceSaveData choiceData = new DSChoiceSaveData()
            {
                Text = "Siguiente Diálogo"
            };

            Choices.Add(choiceData);

        }

        public override void Draw()
        {
            base.Draw();

            /* Contenedor Principal*/
            Button addChoiceButton = DSElementUtility.CreateButton("Añadir opción", () =>
            {
                DSChoiceSaveData choiceData = new DSChoiceSaveData()
                {
                    Text = "Nueva opción"
                };

                Choices.Add(choiceData);

                Port choicePort = CreateChoicePort(choiceData);

                outputContainer.Add(choicePort);



            });

            addChoiceButton.AddToClassList("ds-node__button");

            mainContainer.Insert(1, addChoiceButton);

            /* Contenedor de salida */
            foreach (DSChoiceSaveData choice in Choices)
            {
                Port choicePort = CreateChoicePort(choice);

                outputContainer.Add(choicePort);
            }

            RefreshExpandedState();

        }

        #region Creación de elementos
        private Port CreateChoicePort(object userData)
        {
            Port choicePort = this.CreatePort();

            choicePort.userData = userData;

            DSChoiceSaveData choiceData = (DSChoiceSaveData)userData;

            Button deleteChoiceButton = DSElementUtility.CreateButton("Eliminar", () =>
            { 
                if(Choices.Count == 1)
                {
                    return;
                }

                if(choicePort.connected)
                {
                    graphView.DeleteElements(choicePort.connections);

                }

                Choices.Remove(choiceData);
                graphView.RemoveElement(choicePort);
            
            });

            deleteChoiceButton.AddToClassList("ds-node__button");

            TextField choiceTextField = DSElementUtility.CreateTextField(choiceData.Text, null, callback =>
            {
                choiceData.Text = callback.newValue;
            });

            choiceTextField.AddClasses(
                "ds-node__textfield",
                "ds-node__choice-textfield",
                "ds-node__textfield__hidden"
                );

            choicePort.Add(choiceTextField);
            choicePort.Add(deleteChoiceButton);
            return choicePort;
        }
        #endregion
    }
}
