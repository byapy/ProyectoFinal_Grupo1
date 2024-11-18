using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaccion_Npc : MonoBehaviour
{
    public bool isPlayerInRange;

    public Animator animatorNpc;

    void Start()
    {
        animatorNpc = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.Q))
        {
            Talk();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Debug.Log("Presiona Q para interactuar");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            Debug.Log("saliste del rango de interaccion");
            animatorNpc.SetBool("isTalking", false);
        }
    }

    public void Talk()
    {
        Debug.Log("Hola viajero, ten cuidado por este camino, muchos dicen que el mundo se acabara");
        animatorNpc.SetBool("isTalking", true);
    }
}
