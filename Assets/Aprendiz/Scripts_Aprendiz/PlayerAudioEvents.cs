using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class PlayerAudioEvents : MonoBehaviour
{
    //Variables de Audio
    
    public AudioClip ClipCaminar;
    public AudioClip ClipCorrer;
    public AudioClip ClipIdle;
    public AudioClip Clipland;
    public AudioClip ClipMuerte;

    public AudioSource SourceBlendTree;
    public void Caminar()
    {
        SourceBlendTree.Stop();
        SourceBlendTree.PlayOneShot(ClipCaminar);
    }
    public void Correr()
    {
        SourceBlendTree.Stop();
        SourceBlendTree.PlayOneShot(ClipCorrer);
    }
    public void Idle()
    {
        SourceBlendTree.Stop();
        SourceBlendTree.PlayOneShot(ClipIdle);
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
