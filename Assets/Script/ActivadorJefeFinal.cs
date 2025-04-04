using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActivadorJefeFinal : MonoBehaviour
{
    public GameObject LilithActivar;
    public GameObject Torre;
    public GameObject ColisionEntrada;

    void Start()
    {
        LilithActivar.SetActive(false);
        ColisionEntrada.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (LilithActivar != null)
            {
                LilithActivar.SetActive(true); 
                ColisionEntrada.SetActive(true);
                Destroy(Torre);



            }
        }
    }
}
