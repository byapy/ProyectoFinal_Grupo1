using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GolpeConfirm : MonoBehaviour
{

    public Collider espadaCollider;
    public GameObject ParticulasHIT;
    public GameObject visualtest;

    private SonidoAleatorio SonidoSeleccion;

    public AudioSource GolpesSource;
    public AudioClip Golpe1Clip;
    public AudioClip Golpe2Clip;
    public AudioClip Golpe3Clip;

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
    private enum SonidoAleatorio
    {
        Sonido1,
        Sonido2,
        Sonido3
        
    }
    


    public void Golpe()
    {
        SonidoSeleccion = (SonidoAleatorio)Random.Range(0, System.Enum.GetValues(typeof(SonidoAleatorio)).Length);

        switch (SonidoSeleccion)
        {
            case SonidoAleatorio.Sonido1:
                GolpesSource.PlayOneShot(Golpe1Clip);
                break;

            case SonidoAleatorio.Sonido2:
                GolpesSource.PlayOneShot(Golpe2Clip);
                break;
            case SonidoAleatorio .Sonido3:
                GolpesSource.PlayOneShot(Golpe3Clip);
                break;

        }

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
           // StatsPlayer.Instance.ReceivedDamage(JefaLilith.Instance.Daño);
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
