using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarCamaras : MonoBehaviour
{
    public GameObject camaraFPS;
    public GameObject camaraTPS;
    public GameObject Hacha;
    public GameObject arma;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CambioCamaras();
    }

    void CambioCamaras()
    {
        if(Input.GetKey(KeyCode.K))

        {
            camaraFPS.SetActive(true);
            camaraTPS.SetActive(false);
            GetComponent<ThirdPersonMovement>().enabled = false;
            GetComponent<FPSCharacterController>().enabled = true;
            Hacha.SetActive(false);
            arma.SetActive(true);
        }
        if (Input.GetKey(KeyCode.L))
        {
            camaraFPS.SetActive(false);
            camaraTPS.SetActive(true);
            GetComponent<ThirdPersonMovement>().enabled = true;
            GetComponent<FPSCharacterController>().enabled = false;
            Hacha.SetActive(true);
            arma.SetActive(false);
        }
    }
}
