using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventoDisparo : MonoBehaviour
{
    private MaestraNegra maestra;

    private void Start()
    {
        maestra = GetComponentInParent<MaestraNegra>();
    }

    public void Disparar()
    {
        if (maestra != null)
        {
            maestra.Disparo();
        }
    }
}
