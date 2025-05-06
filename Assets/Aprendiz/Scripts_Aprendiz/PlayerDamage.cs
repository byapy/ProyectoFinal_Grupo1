using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            movimientoEnemigo.Instance.ReceivedDamage(StatsPlayer.Instance.CalcularAtaque());
        }
    }



}
