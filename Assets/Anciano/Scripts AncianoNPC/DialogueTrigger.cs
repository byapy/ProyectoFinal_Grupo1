using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject PanelDialogo;
    public static DialogueTrigger Instance;
    [SerializeField] private Animator NPCAnimator;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        NPCAnimator = GetComponentInParent<Animator>();

    }
    public void TriggerDialogue()
    {
        NPCAnimator.SetBool("Talk", true);
        PanelDialogo.SetActive(true);
        FindObjectOfType<DialogueManager>().StartDialogo(dialogue);
    }
    public void TriggerDesactivar()
    {
        Debug.Log("Se entró al TriggerDesactivar");
        NPCAnimator.SetBool("Talk", false);
        PanelDialogo.SetActive(false);
        MovAnimacionesArmas.Instance.DesactivarHablarNPC();
    }
}