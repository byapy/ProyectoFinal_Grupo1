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
                GameObject PersonajeFull = GameObject.Find("AprendizArmasConfigurado");
                PersonajeFull.SetActive(false);
                PersonajeFull.transform.SetPositionAndRotation(VaHacia.position, VaHacia.rotation);
                other.gameObject.transform.SetPositionAndRotation(VaHacia.position, VaHacia.rotation);

                PersonajeFull.SetActive(true);
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
