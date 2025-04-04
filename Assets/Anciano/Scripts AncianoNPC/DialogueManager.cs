using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;

    public Text nameText;
    public Text dialogoText;


    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogo(Dialogue dialogue)//Empieza la conversacion CARGA LAS ORACIONES DEL NPC
    {
        Debug.Log("Has iniciado la conversacion de " + dialogue.name);
        nameText.text = dialogue.name;

        sentences.Clear();//Limpia los espacios

        foreach (string sentence in dialogue.sentences) //agarra oracion por oracion
        {
            sentences.Enqueue(sentence);

        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()//Revisa si ya se leyeron, es como un bucle, hasta llegar al count 0 que son las oraciones
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue(); //le estoy diceindo que me despliegue las oraciones en la consola
        dialogoText.text = sentence;
    }

    void EndDialogue()
    {
        Debug.Log("Has acabado la conversacion");
    }
}
