using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
public class EmpezarConversacion : MonoBehaviour
{
    [SerializeField] private NPCConversation npcDialogo;
    [SerializeField] private GameObject ButtonPrompt, CamaraNPC, CamaraPlayer;

    private bool EmpezoDialogo;

    private void Start()
    {
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.F))
            {
                EmpezoDialogo = true;
                ButtonPrompt.SetActive(false);
                CamaraNPC.SetActive(true);
                CamaraPlayer.SetActive(false);
                ConversationManager.Instance.StartConversation(npcDialogo);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        TerminoConversacion();
        ConversationManager.Instance.EndConversation();
    }

    public void TerminoConversacion()
    {
        CamaraNPC.SetActive(false);
        CamaraPlayer.SetActive(true);
    }



}
