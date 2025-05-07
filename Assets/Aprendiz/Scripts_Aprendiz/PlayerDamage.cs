using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public GameObject ParticulaGolpe;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            movimientoEnemigo.Instance.ReceivedDamage(StatsPlayer.Instance.CalcularAtaque());
           Instantiate (ParticulaGolpe, transform.position, Quaternion.identity);
        }
        

    }



}
