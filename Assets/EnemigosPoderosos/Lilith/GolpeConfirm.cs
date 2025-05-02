using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolpeConfirm : MonoBehaviour
{
    public GameObject EspadaHit;
    private Collider espadaCollider;

    public void Awake()
    {
        espadaCollider = EspadaHit.GetComponent<Collider>();
        espadaCollider.enabled = false;
    }
    public void Golpe()
    {
        Debug.Log("Golpe Realizado");
        espadaCollider.enabled = true;
        StartCoroutine(DesactivarCollider());


        if (JefaLilith.Instance != null && JefaLilith.Instance.Fases == 2 && JefaLilith.Instance.CuracionON)
        {

            JefaLilith.Instance.CurarsePorGolpe(); // Llama a la curación si está en fase 2
        }

    }
    private IEnumerator DesactivarCollider()
    {
        yield return new WaitForSeconds(1f); 
        espadaCollider.enabled = false;  
    }
    public void Terminado()
    {
        JefaLilith.Instance.TerminarAnimacion();
    }
}
