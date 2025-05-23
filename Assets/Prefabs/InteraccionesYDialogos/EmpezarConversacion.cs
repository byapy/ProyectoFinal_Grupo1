using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
public class EmpezarConversacion : MonoBehaviour
{
    [SerializeField] private NPCConversation npcDialogo;
    [SerializeField] private GameObject ButtonPrompt, CamaraNPC, CamaraPlayer;

    private void Start()
    {
        CamaraPlayer = GameObject.Find("CameraAprediz");
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.F))
            {
                MovAnimacionesArmas.Instance.ActivarHablarNPC();
                ButtonPrompt.SetActive(false);
                CamaraNPC.SetActive(true);
                CamaraPlayer.SetActive(false);
                ConversationManager.Instance.StartConversation(npcDialogo);
            }

            if(Input.GetKey(KeyCode.Escape))
            {
                TerminoConversacion();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        TerminoConversacion();
    }

    public void TerminoConversacion()
    {
        MovAnimacionesArmas.Instance.DesactivarHablarNPC();

        ConversationManager.Instance.EndConversation();
        CamaraNPC.SetActive(false);
        CamaraPlayer.SetActive(true);
    }
}
