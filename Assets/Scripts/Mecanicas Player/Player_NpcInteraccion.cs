using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_NpcInteraccion : MonoBehaviour
{
    public GameObject Npc;

    void Start()
    {

    }

    void Update()
    {
        if (Npc != null && Input.GetKeyDown(KeyCode.Q))
        {
            Npc.GetComponent<Interaccion_Npc>().Talk();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            Npc = other.gameObject;
            Debug.Log("Presiona Q para hablar");
        }
    }

}