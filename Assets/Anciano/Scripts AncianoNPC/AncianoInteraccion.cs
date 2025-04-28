using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AncianoInteraccion : MonoBehaviour
{
    public PlayerController playerController;
    public DialogueTrigger dialogueTrigger;

    //Dialogos por nivel
    public Dialogue nivel1Dialogue;
    public Dialogue nivel2Dialogue;
    public Dialogue nivel3Dialogue;
    public Dialogue nivel4Dialogue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int nivelActual = playerController.nivelProgreso;

            //Muestra los dialogos dependiendo del nivel que registra en el nivel progreso
            if (nivelActual == 0)
            {
                dialogueTrigger.dialogue = nivel1Dialogue;
            }
            else if (nivelActual == 1)
            {
                dialogueTrigger.dialogue = nivel2Dialogue;
            }
            else if (nivelActual == 2)
            {
                dialogueTrigger.dialogue = nivel3Dialogue;
            }
            else if (nivelActual >= 3)
            {
                dialogueTrigger.dialogue = nivel4Dialogue;
            }

            dialogueTrigger.TriggerDialogue();
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            dialogueTrigger.TriggerDesactivar();
        }
    }
}
