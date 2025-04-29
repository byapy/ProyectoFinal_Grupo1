using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerSingleton : MonoBehaviour
{
    public static managerSingleton unicaInstancia;

    private void Awake()
    {
        if(managerSingleton.unicaInstancia == null)
        {
            managerSingleton.unicaInstancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
