using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class EmpezarDialogo : MonoBehaviour
{

    public NPCConversation npcDialogos;


    private void OnTriggerStay(Collider other)
    {
        //Para que se active solo si el jugador está dentro del trigger y presiona un botón
        if(other.CompareTag("Player"))
        {
            if(Input.GetKey(KeyCode.E)) ConversationManager.Instance.StartConversation(npcDialogos);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //desactiva la conversación automáticamente si el jugador se aleja
        ConversationManager.Instance.EndConversation();
    }

}
