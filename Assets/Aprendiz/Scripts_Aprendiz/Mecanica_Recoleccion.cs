using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mecanica_Recoleccion : MonoBehaviour
{
    public static bool[] NivelSuperado = new bool[3];
    public static int Gema;

    private void Awake()
    {
        for(int i = 0; i == 2; i++)
        {
            NivelSuperado[i] = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        switch (other.tag.ToLower())
        {
            case "saco10":
                StatsPlayer.Instance.AgregarDinero(10);
                break;
            case "saco50":
                StatsPlayer.Instance.AgregarDinero(50);
                break;
            case "vida":
                StatsPlayer.Instance.AgregarPocion(other.tag.ToLower());
                break;
            case "defensa":
                StatsPlayer.Instance.AgregarPocion(other.tag.ToLower());
                break;
            case "ataque":
                StatsPlayer.Instance.AgregarPocion(other.tag.ToLower());
                break;
            case "gema":
                Gema += + 1;

                PlayerController.Instance.ActualizarProgreso(Gema);
                EmpezarDialogoAnciano.GemasAgarradas = Gema;
                //para obetener el nivelID de la gema
                NivelSuperado[other.GetComponent<NivelTrigger>().NivelSuperado()] = true;

                if (Gema >= 3)
                {
                    Debug.Log("Has conseguido la gema completa");
                }

                Destroy(other.gameObject);
                break;
            case "respawn":
                Debug.Log("----- Punto de Control -----\n"+other.transform.position);

                CheckPointSystem.PuntoControl = other.transform;

                break;
                //Agregar booleanas con tags de armas
        }
    }
    //Meter en el código lo de añadir las partes de la gema
            

}