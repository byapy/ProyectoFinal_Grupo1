using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarAnimacionesMercader : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator Animaciones_Mercader;

    public static ActivarAnimacionesMercader Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Animaciones_Mercader = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }

    public void Hablando()
    {
        Animaciones_Mercader.SetBool("DebeHablar", true);
    }

    public void YaNoHabla()
    {
        Animaciones_Mercader.SetBool("DebeHablar", false);
    }

    public void SaludarAlJugador()
    {
        Animaciones_Mercader.SetBool("Saluda", true);
    }

    public void TerminarSaludo()
    {
        Animaciones_Mercader.SetBool("Saluda", false);
    }

    public void VentaBuenaInicio()
    {
        Animaciones_Mercader.SetBool("VentaBuena", true);
    }

    public void VentaBuenaFinal()
    {
        Animaciones_Mercader.SetBool("VentaBuena", false);
    }

    public void VentaMalaInicio()
    {
        Animaciones_Mercader.SetBool("VentaMala", true);
    }
    public void VentaMalaFinal()
    {
        Animaciones_Mercader.SetBool("VentaMala", false);
    }

}
