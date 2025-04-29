using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventosDialogos : MonoBehaviour
{
    public dialogos dialogo;
    public GameObject panelDialogo;

    public void eventosOraciones()
    {
        panelDialogo.SetActive(true);
       FindObjectOfType<dialogoManager>().IniciarDialogos(dialogo);
    }
    public void eventosFin()
    {
        panelDialogo.SetActive(false);
    }
}
