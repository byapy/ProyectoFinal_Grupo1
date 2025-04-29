using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogoManager : MonoBehaviour
{
    private Queue<string> Oraciones;

    public Text nombreTexto;
    public Text dialogoTexto;

    void Start()
    {
        Oraciones = new Queue<string>();
    }
    public void IniciarDialogos(dialogos dialogo)
    {
        Debug.Log("inicia la conversacion");
        nombreTexto.text = dialogo.nombre;

        Oraciones.Clear();

        foreach (string oraciones in dialogo.oraciones)
        {
            Oraciones.Enqueue(oraciones);
        }
        mostrarDialogos();
    }
    public void mostrarDialogos()
    {
        if(Oraciones.Count == 0)
        {
            SinDialogos();
            return;
        }
        string oraciones = Oraciones.Dequeue();
        dialogoTexto.text = oraciones;
    }

    void SinDialogos()
    {
        Debug.Log("No hay mas dialogos");
    }
}
