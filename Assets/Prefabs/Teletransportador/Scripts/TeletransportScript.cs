using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeletransportScript : MonoBehaviour
{
    [SerializeField] Transform VaHacia;

    private void OnTriggerEnter(Collider other)
    {
        if (VaHacia != null)
        {
            if (other.CompareTag("Player") && !MovAnimacionesArmas.Teletransporting)
            {
                other.gameObject.SetActive(false);
                other.transform.position = VaHacia.position;
                other.transform.rotation = VaHacia.rotation;

                other.gameObject.SetActive(true);
                MovAnimacionesArmas.Teletransporting = true;
            }
        }
        else Debug.Log("No hay punto para teletransportarse");

    }


    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            MovAnimacionesArmas.Teletransporting = false;
        }

    }

}
