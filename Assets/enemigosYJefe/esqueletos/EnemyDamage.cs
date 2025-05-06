using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float AttackDamage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StatsPlayer.Instance.ReceivedDamage(AttackDamage);
            Debug.Log("Has recibido daño de " + AttackDamage);
        }
    }


}
