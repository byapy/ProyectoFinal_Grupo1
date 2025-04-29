using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class llave : MonoBehaviour
{
    public GameObject plataforma1;
    public GameObject plataforma2;
    public GameObject plataforma3;
    public GameObject plataforma4;
    public GameObject plataforma5;
    public GameObject plataforma6;
    public GameObject plataforma7;
     

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter(Collision objeto)
    {
        if (objeto.transform.tag == "llave")
        {
            Debug.Log("Encontraste la llave");
            Destroy(objeto.transform.gameObject);
            plataforma1.SetActive(true);
            plataforma2.SetActive(true);
            plataforma3.SetActive(true);
            plataforma4.SetActive(true);
            plataforma5.SetActive(true);
            plataforma6.SetActive(true);
            plataforma7.SetActive(true);
        }
    }
}
