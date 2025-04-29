using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetodosMercader : MonoBehaviour
{
    public Animator Animador_Mercader;
    // Start is called before the first frame update
    void Start()
    {
        Animador_Mercader = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hablando()
    {
        Animador_Mercader.SetBool("DebeHablar", true);
    }

    public void YaNoHabla()
    {
        Animador_Mercader.SetBool("DebeHablar", false);
    }

}
