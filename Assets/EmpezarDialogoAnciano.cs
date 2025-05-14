using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class EmpezarDialogoAnciano : MonoBehaviour
{
    [SerializeField] private NPCConversation[] npcDialogo;
    [SerializeField] private GameObject ButtonPrompt, CamaraNPC, CamaraPlayer;
    public static EmpezarDialogoAnciano Instance;

    public static int GemasAgarradas;

    private void Awake()
    {
        Instance = this;
    }

    /*public void ActualizarContador(int GemaRecolectada)
    {
        GemasAgarradas = GemaRecolectada;
    }*/

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(GemasAgarradas);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            if (Input.GetKey(KeyCode.F))
            {
                ButtonPrompt.SetActive(false);
                CamaraNPC.SetActive(true);
                CamaraPlayer.SetActive(false);
                ConversationManager.Instance.StartConversation(npcDialogo[GemasAgarradas]);
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

