using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject PanelDialogo;

    public void TriggerDialogue()
    {
        PanelDialogo.SetActive(true);
        FindObjectOfType<DialogueManager>().StartDialogo(dialogue);
    }
    public void TriggerDesactivar()
    {
        PanelDialogo.SetActive(false);
    }
}