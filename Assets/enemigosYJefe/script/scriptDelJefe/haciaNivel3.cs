using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class haciaNivel3 : MonoBehaviour
{
    public GameObject player;
    public Transform cambioDeZona;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        player.transform.position = cambioDeZona.position;
        player.transform.rotation = cambioDeZona.rotation;
    }
}
