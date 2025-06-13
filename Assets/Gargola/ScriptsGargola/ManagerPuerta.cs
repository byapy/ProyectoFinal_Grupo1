using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerPuerta : MonoBehaviour
{
    [SerializeField]
    GameObject VisagraD, VisagraI;
    // Start is called before the first frame update
    private void Start()
    {
        if(Mecanica_Recoleccion.NivelSuperado[0])
        {
            AbrirPuertas();
        }
    }

    public void AbrirPuertas()
    {
        //LeanTween.rotate(VisagraD, new Vector3(0,300,0), 3f);
        LeanTween.rotateAroundLocal(VisagraD, Vector3.up, 100, 3f).setEase(LeanTweenType.easeInOutSine);
        LeanTween.rotateAroundLocal(VisagraI, Vector3.up, -100, 3f).setEase(LeanTweenType.easeInOutSine);

    }
}
