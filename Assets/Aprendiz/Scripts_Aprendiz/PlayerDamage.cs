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
            other.GetComponent<movimientoEnemigo>().ReceivedDamage(StatsPlayer.Instance.CalcularAtaque());
            Instantiate (ParticulaGolpe, transform.position, Quaternion.identity);
        }
        if (other.CompareTag("Enemy2"))
        {
            other.GetComponent<movimientoEnemigo2>().ReceivedDamage2(StatsPlayer.Instance.CalcularAtaque());
            Instantiate(ParticulaGolpe, transform.position, Quaternion.identity);
        }
        if (other.CompareTag("Enemy3"))
        {
            other.GetComponent<MaestraNegra>().RecibirDaño(StatsPlayer.Instance.CalcularAtaque());
            Instantiate(ParticulaGolpe, transform.position, Quaternion.identity);
        }
        if (other.CompareTag("Jefe"))
        {
            other.GetComponent<movimientoJefe>().ReciveDanoJefe(StatsPlayer.Instance.CalcularAtaque());
            Instantiate(ParticulaGolpe, transform.position, Quaternion.identity);

        }
        if (other.CompareTag("Lilith"))
        {
            Debug.Log("Es lilith");
            JefaLilith.Instance.RecibirDaño(StatsPlayer.Instance.CalcularAtaque());
            Instantiate(ParticulaGolpe, transform.position, Quaternion.identity);

        }
    }



}
