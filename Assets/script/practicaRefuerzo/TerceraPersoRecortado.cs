using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerceraPersoRecortado : MonoBehaviour
{
    //variables de movimiento
    public CharacterController Controlar;
    public float velocidad;
    public float rapidoSmooth = 0.1f;
    public float sensibleSmooth;
    public Transform camara;
    //variables de salto y gravedad
    public Vector3 caer;
    public float gravedad = -9.81f;
    public float separacion = 0.4f;
    public bool EsSuelo;
    public float FuerzaSalto;
    public LayerMask Terreno;
    public Transform deteccion;
    public Animator animacion;
    //variables de animacion
    public bool estaSaltando;
    public bool enTierra;

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
    public void Moverse()
    {
        float moverX = Input.GetAxis("Horizontal");
        float moverZ = Input.GetAxis("Vertical");
        Vector3 direccion = new Vector3(moverX, 0, moverZ).normalized;
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

        if (direccion.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direccion.x, direccion.z) * Mathf.Rad2Deg + camara.eulerAngles.y;//angulo de giro

            float angulo = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref sensibleSmooth, rapidoSmooth);//el giro es mas suave
            transform.rotation = Quaternion.Euler(0, angulo, 0);//giro del personaje

            Vector3 destino = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            Controlar.Move(destino.normalized * velocidad * Time.deltaTime);
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
        Controlar.Move(caer * Time.deltaTime);
    }
}
