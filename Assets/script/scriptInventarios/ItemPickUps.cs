using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUps : MonoBehaviour
{
    public Objetos objeto;

    void Pickup()
    {
        inventarioManager.Instance.Agregar(objeto);
        Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            Pickup();
            inventarioManager.Instance.ListaObjetos();
        }
    }
}
