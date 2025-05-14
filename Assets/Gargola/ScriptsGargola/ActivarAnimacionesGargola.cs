using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarAnimacionesGargola : MonoBehaviour
{
    public Animator Animaciones_Gargola;

    public static ActivarAnimacionesGargola Instance;
    void Start()
    {
        Animaciones_Gargola = GetComponent<Animator>();
    }

    public void ActivarHablado()
    {
        Animaciones_Gargola.SetBool("Talk", true);
    }
    public void DesactivarHablado()
    {
        Animaciones_Gargola.SetBool("Talk", false);
    }

    public void ActivarFlex()
    {
        Animaciones_Gargola.SetBool("Flex", true);

    }

    public void DesactivarFlex()
    {
        Animaciones_Gargola.SetBool("Flex", false);


    }

}
