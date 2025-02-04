using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploArray : MonoBehaviour
{
    [SerializeField] GameObject[] objetos;
    [SerializeField] string[] textos = new string[5];
    [SerializeField] Transform [] Pointer;
    void Start()
    {
        int RangoObjetos = Random.Range(0, objetos.Length);
        int RangoPointer = Random.Range(0, Pointer.Length);
        Instantiate(objetos[RangoObjetos], Pointer[RangoPointer].position, Pointer[RangoPointer].rotation);
    }
    
    void Update()
    {
        Debug.Log(textos[0]);        
    }
}
