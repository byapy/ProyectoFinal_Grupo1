using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCharacter : MonoBehaviour
{
    public Animator animar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButton("Jump"))
        {
            animar.SetBool("Walking", true);
        }
        else
        {
            animar.SetBool("Walking", false);
        }
        if (Input.GetKey(KeyCode.L))
        {
            animar.SetBool("Fireball", true);
        }
        else
        {
            animar.SetBool("Fireball", false);
        }
        if (Input.GetKey(KeyCode.K))
        {
            animar.SetBool("Upward", true);
        }
        else
        {
            animar.SetBool("Upward", false);
        }
    }

}
