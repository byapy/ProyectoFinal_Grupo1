using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caso2Re : MonoBehaviour
{
    public GameObject cubo;
    public int numero1;
    public int numero2;
    public int Total;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        Total = numero1 + numero2;
        if (Total == 5)
        {
        cubo.transform.Rotate(1, 0, 0);
        Debug.Log("El cubo esta girando porque el valor es 5");
        }
    }
}
