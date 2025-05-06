using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolpeConfirm : MonoBehaviour
{

    public Collider espadaCollider;
    public GameObject ParticulasHIT;
    public Transform PointerParticulas;
    private bool golpeActivo = false;
    private bool yaGolpeo = false;

    private void Awake()
    {
        espadaCollider = GetComponentInChildren<Collider>();
        espadaCollider.isTrigger = true;
    }
    public void Update()
    {
        Debug.Log("VIDA: " + StatsPlayer.PVidaActual);
    }


    public void Golpe()
    {
        Debug.Log("Golpe Realizado");
        golpeActivo = true;
        yaGolpeo = false;
        espadaCollider.enabled = true;
        StartCoroutine(DesactivarCollider());
        Instantiate(ParticulasHIT, PointerParticulas);
    }

    private IEnumerator DesactivarCollider()
    {
        yield return new WaitForSeconds(3f); 
        espadaCollider.enabled = false;
        golpeActivo = false;
        yaGolpeo = false;
        Debug.Log("La colisión de la espada está desactivada");
    }

    public void Terminado()
    {
        JefaLilith.Instance.TerminarAnimacion();


    }

    private void OnTriggerEnter(Collider other)
    {
        if (!golpeActivo || yaGolpeo) return;

        if (other.CompareTag("Player"))
        {
            AplicarDaño();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!golpeActivo || yaGolpeo) return;

        if (other.CompareTag("Player"))
        {
            AplicarDaño();
        }
    }

    private void AplicarDaño()
    {
        if (StatsPlayer.Instance != null)
        {
            StatsPlayer.Instance.ReceivedDamage(15);
            Debug.Log("Jugador recibió daño: 15");

            if (JefaLilith.Instance != null &&
                JefaLilith.Instance.Fases == 2 &&
                JefaLilith.Instance.CuracionON)
            {
                JefaLilith.Instance.CurarsePorGolpe();
            }

            yaGolpeo = true;
        }
    }
}
