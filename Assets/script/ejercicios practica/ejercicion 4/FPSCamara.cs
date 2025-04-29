using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamara : MonoBehaviour
{
    public float rotX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotX = Input.GetAxis("Mouse Y");
        transform.Rotate(rotX, 0, 0);
    }
}
