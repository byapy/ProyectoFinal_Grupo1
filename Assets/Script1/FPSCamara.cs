using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamara : MonoBehaviour
{
    public float RotX;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotX = Input.GetAxis("Mouse Y");
        transform.Rotate(RotX, 0, 0);
    }
}
