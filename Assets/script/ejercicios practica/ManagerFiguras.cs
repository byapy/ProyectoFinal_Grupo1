using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerFiguras : MonoBehaviour
{
    public GameObject cubito;
    public GameObject esfera;
    public GameObject cilindro;

    public GameObject objeto;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(objeto, cubito.transform.position, cubito.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        esfera.transform.Translate(0, 0.1f, 0);
        cubito.transform.Rotate(0.1f, 0, 0);
        cilindro.transform.Translate(0, 0, 0.1f);
        if (Input.GetButtonDown("Jump"))
        {

        }
    }
}
