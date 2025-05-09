using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents : MonoBehaviour
{
    [SerializeField] private UnityEvent EntrarPlayer;
    [SerializeField] public UnityEvent ExitPlayer;
    public static PlayerEvents Instance;

    private void Awake()
    {
        Instance = this;
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
}