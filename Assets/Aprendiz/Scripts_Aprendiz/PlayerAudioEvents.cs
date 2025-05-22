using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class PlayerAudioEvents : MonoBehaviour
{
    //Variables de Audio
    
    public AudioClip ClipCaminarD;
    public AudioClip ClipCaminarI;
    public AudioClip ClipCorrer;
    public AudioClip ClipIdle;
    public AudioClip Clipland;
    public AudioClip ClipMuerte;

    public AudioSource SourceBlendTree;
    public void CaminarDerecho()
    {
    
        SourceBlendTree.PlayOneShot(ClipCaminarD);
    }
    public void CaminarIzquierdo()
    {
        SourceBlendTree.PlayOneShot(ClipCaminarI);

    }
    public void Correr()
    {
        if (SourceBlendTree.clip != ClipCorrer)
        {
            SourceBlendTree.clip = ClipCorrer;
            SourceBlendTree.Play();
        }
    }
    public void Idle()
    {
        if (SourceBlendTree.clip != ClipIdle)
        {
            SourceBlendTree.clip = ClipIdle;
            SourceBlendTree.Play();
        }
    }
   
    
    public void Salto()
    {
        SourceBlendTree.Stop();
        SourceBlendTree.PlayOneShot(Clipland);
    }
    public void Muerte()
    {
        SourceBlendTree.Stop();
        SourceBlendTree.PlayOneShot(ClipMuerte);
    }
}
