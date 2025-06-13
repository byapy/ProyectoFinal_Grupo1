using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeletransporteN2 : MonoBehaviour
{
    [SerializeField] int GemaAsociada = -1;
    [SerializeField] GameObject PortalAActivar;
    private void Start()
    {
        ActivarPortal();
    }

    private void ActivarPortal()
    {
        if (GemaAsociada < 0 || GemaAsociada > 3) return;

        if (Mecanica_Recoleccion.NivelSuperado[GemaAsociada])
            PortalAActivar.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
