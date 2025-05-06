using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public Vector3 BalaInstancia;
    float BalaDamage;

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
        if(other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            movimientoEnemigo.Instance.ReceivedDamage(BalaDamage);
        }
    }
}
