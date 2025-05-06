using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolpeMaestra : MonoBehaviour
{
    private Collider golpeCollider;
    public float tiempoDesactivado = 2f;
    public void Start()
    {
        golpeCollider = GetComponent<Collider>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StatsPlayer.Instance.ReceivedDamage(MaestraNegra.Instance.DañoG);
            StartCoroutine(DesactivarTemporalmente());

        }

    }

    private IEnumerator DesactivarTemporalmente()
    {
        golpeCollider.enabled = false;
        yield return new WaitForSeconds(tiempoDesactivado);
        golpeCollider.enabled = true;
    }

}
