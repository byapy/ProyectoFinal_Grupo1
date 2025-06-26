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
            StatsPlayer.Instance.ReceivedDamage(AttackDamage / 3);
            Debug.Log("Has recibido daño de " + AttackDamage);

            if (JefaLilith.Instance != null &&
                JefaLilith.Instance.Fases == 2 &&
                JefaLilith.Instance.CuracionON)
            {
                JefaLilith.Instance.CurarsePorGolpe();
            }

        }
    }


}
