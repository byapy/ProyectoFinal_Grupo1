using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
public class EmpezarConversacion : MonoBehaviour
{
    [SerializeField] private NPCConversation[] npcDialogo;
    [SerializeField] private GameObject ButtonPrompt, CamaraNPC, CamaraPlayer, ItemNPC, ParticulaItem;
    [SerializeField] private int ramaDialogoActual;

    private void Awake()
    {
        if(Mecanica_Recoleccion.NivelSuperado[0])
        {
            ramaDialogoActual = 3;
        }
    }
    private void Start()
    {
        CamaraPlayer = GameObject.Find("CameraAprediz");

    }

    public void NuevoDialogo(int nuevoDialogo)
    {
        ramaDialogoActual = nuevoDialogo;
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
                ConversationManager.Instance.StartConversation(npcDialogo[ramaDialogoActual]);
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

    public void AparecerObjeto()
    {
        Instantiate(ParticulaItem, ItemNPC.transform.position, Quaternion.identity);
        ItemNPC.SetActive(true);
    }

    public void ActivarCamaraPlayer()
    {
        CamaraNPC.SetActive(false);
        CamaraPlayer.SetActive(true);
    }
}
