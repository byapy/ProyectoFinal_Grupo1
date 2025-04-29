using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caso3Re : MonoBehaviour
{
    public GameObject objeto1;
    public GameObject luz1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            luz1.SetActive(true);
            Debug.Log("La luz esta encendida");
        }
        if (Input.GetMouseButtonDown(1))
        {
            luz1.SetActive(false);
            Debug.Log("La luz esta apagada");
        }
        if (Input.GetKey(KeyCode.K))
        {
         Instantiate(objeto1, transform.position, transform.rotation);
        }

    }
}
