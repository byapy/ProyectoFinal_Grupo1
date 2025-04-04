using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacionNpc : MonoBehaviour
{
    public Animator AnimatorNpc;
    public bool enConversacion;
    
    public void ActivarHablarNPC()
    {
        enConversacion = true;
        AnimatorNpc.SetBool("Talk", true);
    }

    public void DesactivarHablarNPC()
    {
        enConversacion = false;
        AnimatorNpc.SetBool("Talk", false);
    }
}
