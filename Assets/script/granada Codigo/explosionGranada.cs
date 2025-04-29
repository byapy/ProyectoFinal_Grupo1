using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosionGranada : MonoBehaviour
{
    public float radio;
    public float fuerzaExplosion;
    public float tiempoRetraso;
    public GameObject particulaExplota;
    public GameObject radioExplosion;

    public AudioClip clipExplosion;
    public AudioSource fuente2;
    void Start()
    {
        Invoke("explotarGranada", tiempoRetraso);
    }

   
    void Update()
    {
        
    }

    void explotarGranada()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radio);

        foreach (Collider objetoCollider in colliders)
        {
            Rigidbody rb = objetoCollider.GetComponent<Rigidbody>();

            if( rb != null)
            {
                rb.AddExplosionForce(fuerzaExplosion, transform.position, radio, 1f, ForceMode.Impulse); 
            }
            //radioExplosion.SetActive(true);
            fuente2.PlayOneShot(clipExplosion);
            
            Instantiate(particulaExplota, transform.position, transform.rotation);
            Destroy(gameObject, 2f);

        }
    }
             
}
