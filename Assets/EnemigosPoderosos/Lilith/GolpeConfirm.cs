using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GolpeConfirm : MonoBehaviour
{

    public Collider espadaCollider;
    public GameObject ParticulasHIT;
    public GameObject visualtest;

    public AudioSource GolpesSource;
    public AudioClip Golpe1Clip;
    public AudioClip Golpe2Clip;
    public AudioClip impactoClip;
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
        GolpesSource.PlayOneShot(Golpe1Clip);
        GolpesSource.PlayOneShot(impactoClip);

        visualtest.SetActive(true);
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
        espadaCollider.enabled = false;
        visualtest.SetActive(false);



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
