using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminar_Juego : MonoBehaviour
{
    public GameObject CamaraCinematica;
    public GameObject Interfaz;
    public GameObject JugadorL;
    public GameObject Muñeco;
    private void Awake()
    {
        
    }
    void Start()
    {
        JugadorL = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (JefaLilith.Instance.VidaLilith == 0)
            {
                Muñeco.SetActive(true);
                Destroy(JugadorL);
                Destroy(Interfaz);
                CamaraCinematica.SetActive(true);
                Debug.Log("CinematicaCorriendo");
            }
        }
            
    }
}
