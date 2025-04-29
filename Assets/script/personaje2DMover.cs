using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personaje2DMover : MonoBehaviour
{
    public CharacterController controlar;
    public float velocidad;
    public float velocidadRotar;
    public Vector3 direccion;

    public Vector3 caer;
    public float gravedad = -9.81f;
    public float separacion = 0.4f;
    public bool EsSuelo;
    public float FuerzaSalto;
    public LayerMask Terreno;
    public Transform deteccion;
    public Animator animacion;

    public bool estaSaltando;
    public bool enTierra;
    // Start is called before the first frame update
    void Start()
    {
    animacion = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Moverse();
        Saltar();
    }

    void Moverse()
    {
        float MoverH = Input.GetAxis("Horizontal");
        direccion = new Vector3(0, 0, MoverH).normalized;
        float Magnitud = Mathf.Clamp01(direccion.magnitude);

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            Magnitud /= 0.5f;
            velocidad = 15;
        }
        else
        {
            velocidad = 7;
        }
        animacion.SetFloat("Input Magnitud", Magnitud, 0.05f, Time.deltaTime);

        if (direccion != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(direccion, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, velocidadRotar * Time.deltaTime);
            controlar.Move(direccion.normalized * velocidad * Time.deltaTime);
        }
    }
    public void Saltar()
    {
        EsSuelo = Physics.CheckSphere(deteccion.position, separacion, Terreno);
        if (EsSuelo && caer.y < 0)
        {
            caer.y = -2f;
            animacion.SetBool("Es suelo", true);
            enTierra = true;
            animacion.SetBool("Saltar", false);
            estaSaltando = false;
        }
        else
        {
            animacion.SetBool("Es suelo", false);
            enTierra = false;

            if (estaSaltando && caer.y < 0)
            {
                animacion.SetBool("En aire", true);
            }
        }

        if (Input.GetButtonDown("Jump") && EsSuelo)
        {
            animacion.SetBool("Saltar", true);
            estaSaltando = true;
            caer.y = Mathf.Sqrt(FuerzaSalto * -2f * gravedad);

        }
        caer.y += gravedad * Time.deltaTime;
        controlar.Move(caer * Time.deltaTime);
    }
}
