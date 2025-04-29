using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comida : MonoBehaviour
{

    [SerializeField] GameObject[] comida;
    [SerializeField] Transform[] inicio;
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        colocar();
        
    }
    public void colocar()
    {
        int RangoComida = Random.Range(0, comida.Length);
        int RangoInicio = Random.Range(0, inicio.Length);
        Instantiate(comida[RangoComida], inicio[RangoInicio].position, inicio[RangoInicio].rotation);
    }    
}
