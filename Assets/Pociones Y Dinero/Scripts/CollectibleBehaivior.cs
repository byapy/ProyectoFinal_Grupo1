using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleBehaivior : MonoBehaviour
{
    //variable para Ui
    public ItemUI ItemCorrespondiente;

    //public string ColorPocion;
    public GameObject ParticulaRecolectado;
    // Start is called before the first frame update  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            try
            {
                Instantiate(ParticulaRecolectado, other.transform.position, transform.rotation);
            }
            catch(System.Exception ex)
            {
                UIController.Instance.MensajeAConsola("error: " + ex.Message);
            }
            finally
            {
                Destroy(gameObject);
            }
        }
    }



}
