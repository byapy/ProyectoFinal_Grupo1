using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents : MonoBehaviour
{
    [SerializeField] private UnityEvent EntrarPlayer;
    [SerializeField] private UnityEvent PresionaTeclaF;
    [SerializeField] private UnityEvent PresionaEscape;

    [SerializeField] private UnityEvent Destruccion;
    [SerializeField] public UnityEvent ExitPlayer;


    public static PlayerEvents Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        { 
            if (Input.GetKey(KeyCode.F))
            {
                PresionaTeclaF.Invoke();
            }

            if (Input.GetKey(KeyCode.Escape))
            {
                PresionaEscape.Invoke();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            EntrarPlayer.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            ExitPlayer.Invoke();
        }
    }

    private void OnDestroy()
    {
        Destruccion.Invoke();
    }
}