using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class Bala : MonoBehaviour
{
    public Vector3 BalaInstancia;
    float BalaDamage;
    public GameObject  ParticulaExplocion;

    

    void Start()
    {
        BalaDamage = StatsPlayer.Instance.CalcularAtaque();

        Destroy(gameObject, 2f);
    }


    void Update()
    {
        transform.Translate(BalaInstancia);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Pego en " + other.tag);

        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<movimientoEnemigo>().ReceivedDamage(StatsPlayer.Instance.CalcularAtaque());
            Destroy(gameObject);
        }
        if (other.CompareTag("Enemy2"))
        {
            other.GetComponent<movimientoEnemigo2>().ReceivedDamage2(StatsPlayer.Instance.CalcularAtaque());
            Destroy(gameObject);
        }
        if (other.CompareTag("Enemy3"))
        {
            other.GetComponent<MaestraNegra>().RecibirDaño(StatsPlayer.Instance.CalcularAtaque());
            Destroy(gameObject);
        }
        if (other.CompareTag("Jefe"))
        {
            other.GetComponent<movimientoJefe>().ReciveDanoJefe(StatsPlayer.Instance.CalcularAtaque());
            Destroy(gameObject);
        }
        if (other.CompareTag("Lilith"))
        {
            Debug.Log("Es lilith");

            JefaLilith.Instance.RecibirDaño(StatsPlayer.Instance.CalcularAtaque());
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Instantiate(ParticulaExplocion, transform.position, Quaternion.identity);
    }
}
