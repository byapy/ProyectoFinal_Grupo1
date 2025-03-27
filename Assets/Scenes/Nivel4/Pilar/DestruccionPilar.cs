using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruccionPilar : MonoBehaviour
{
    public GameObject PilarIntacto;
    public GameObject PilarDestruido;
    public float VidaPilar;
    public GameObject ParticulaDest;
    void Start()
    {
        PilarDestruido.SetActive(false);
    }

    void Update()
    {
        if (VidaPilar <= 0)
        {
            Destruido();

        };
    }
    void Destruido()
    {
        Debug.Log("Un pilar ha sido destruido");
        PilarIntacto.SetActive(false);
        PilarDestruido.SetActive(true);
        ParticulaDest.SetActive(true);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if ((collision.transform.tag == "LilithArma"))//Remplazar esto por el arma de Lilith
        {
            Debug.Log("Se le hizo daño a un pilar");
            VidaPilar = VidaPilar - 1;
        }
    }
    
}
