using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activarObjetosEnAnimacion : MonoBehaviour
{
    public GameObject particula1;
    public GameObject esfera;
    public GameObject esferaJefe;
    public GameObject niebla;

    public Transform jefeEscudo;
    //public Transform escudoAura;
    

    public void activarEscudo()
    {
       
        

        particula1.SetActive(true);
       esfera.SetActive(true);
    }

    public void desactivarEscudo()
    {
        
        particula1.SetActive(false);
       esfera.SetActive(false);
    }

    public void activarColisionArma()
    {
        esferaJefe.SetActive(true);
    }

    public void desactivarColisionArma()
    {
        esferaJefe.SetActive(false);
    }

    public void recuperaSaludJefe()
    {
       if(movimientoJefe.saludJefe < 2500f)
        {
         movimientoJefe.saludJefe = movimientoJefe.saludJefe + 100f;
        }
        
       
    }

    public void derrotaJefe()
    {
        niebla.SetActive(true);
    }
}
