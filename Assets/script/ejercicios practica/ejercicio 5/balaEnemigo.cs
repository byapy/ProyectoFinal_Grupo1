using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balaEnemigo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento2();
    }

    public void Movimiento2()
    {

        Vector3 movimiento = new Vector3(0, 0, 0.9f);
        transform.Translate(movimiento);
    }
}
