using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class luna : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - PlayerController.CamaraPlayer.transform.position);
    }
}
