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

        if (other.CompareTag("Enemy2"))
        {
            movimientoEnemigo2.Instance.ReceivedDamage2(StatsPlayer.Instance.CalcularAtaque());
            Instantiate(ParticulaGolpe, transform.position, Quaternion.identity);
        }

        if (other.CompareTag("Jefe"))
        {
            movimientoJefe.Instance.ReciveDanoJefe(StatsPlayer.Instance.CalcularAtaque());
            Instantiate(ParticulaGolpe, transform.position, Quaternion.identity);

        }
        if (other.CompareTag("Lilith"))
        {
           
            JefaLilith.Instance.RecibirDaño(StatsPlayer.Instance.CalcularAtaque());
            Instantiate(ParticulaGolpe, transform.position, Quaternion.identity);

        }
    }



}
