using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonInteraccionCamara : MonoBehaviour
{
    [SerializeField] private Camera camara;

    private void Update()
    {
        transform.rotation = camara.transform.rotation;
    }


    public void ActivarInstruccion()
    {
        gameObject.SetActive(true);
    }

    public void DesactivarInstruccion()
    {
        gameObject.SetActive(false);
    }

}
