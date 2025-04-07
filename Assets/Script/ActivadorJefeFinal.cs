using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActivadorJefeFinal : MonoBehaviour
{
    public GameObject LilithActivar;
    public GameObject Torre;
    public GameObject ColisionEntrada;
    public GameObject BarraVida;

    void Start()
    {
        LilithActivar.SetActive(false);
        ColisionEntrada.SetActive(false);
        BarraVida.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (LilithActivar != null)
            {
                LilithActivar.SetActive(true); 
                ColisionEntrada.SetActive(true);
                BarraVida.SetActive(true);
                Destroy(Torre);



            }
        }
    }
}
