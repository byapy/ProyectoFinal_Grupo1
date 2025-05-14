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
        EmpezoDialogo = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F) && !EmpezoDialogo)
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
        
    }

    public void TerminoConversacion()
    {
        EmpezoDialogo = false;

        CamaraNPC.SetActive(false);
        CamaraPlayer.SetActive(true);
    }



}
