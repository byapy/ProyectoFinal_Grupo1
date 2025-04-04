using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MovAnimacionesArmas : MonoBehaviour
{
    public CharacterController Controller;
    public float Speed;
    public float SpeedWalk;
    public float SpeedRun;


    public float VelocitySmooth = 0.1f;
    public float SensivitySmooth;

    public Transform cam;

    public Vector3 VelocidadGravedad;
    public float gravedad = -9.81f;

    public Transform GroundCheck;
    public float GroundDistance;
    //public float GroundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;

    public float HeightJump;

    public Animator animator;
    public bool isJump;
    public bool isGround;
    public bool isFalling;

    public GameObject EsferaAtaque;
    public GameObject EsferaLaza;
    public GameObject EsferaEspada;

    public bool ArmaLanza;
    public bool ArmaEspada;
    public bool ArmaMosquete;


    //Abajo son variables de armas
    public GameObject personajeSinArma;
    public GameObject personajeConLanza;
    public GameObject personajeConEspada;
    public GameObject personajeMosquete;

    public InstanciaBala instanciaBala;

    public float tiempoInactivoParaRegresar;
    public float tiempoUltimoUso;

    public GameObject ParticulaCambioArma;

    //private AnimacionNpc animacionNpc;
    public Animator AnimatorNpc;
    public bool enConversacion;



    void Start()
    {
        ActivarPersonajeSinArma();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (ArmaLanza)
            {
                ActivarPersonajeLanza();
                ArmaLanza = false;
            }
            else
            {
                ActivarPersonajeLanza();
                ArmaLanza = true;
                ArmaEspada = false;
                ArmaMosquete = false;

                Instantiate(ParticulaCambioArma, transform.position, Quaternion.identity);

            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (ArmaEspada)
            {
                ActivarPersonajeEspada();
                ArmaEspada = false;
            }
            else
            {
                ActivarPersonajeEspada();
                ArmaLanza = false;
                ArmaEspada = true;
                ArmaMosquete = false;
                Instantiate(ParticulaCambioArma, transform.position, Quaternion.identity);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (ArmaMosquete)
            {
                ActivarPersonajeMosquete();
                ArmaMosquete = false;
            }
            else
            {
                ActivarPersonajeMosquete();
                ArmaLanza = false;
                ArmaEspada = false;
                ArmaMosquete = true;
                Instantiate(ParticulaCambioArma, transform.position, Quaternion.identity);
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            ActivarPersonajeSinArma();
            ArmaMosquete = false;//para que no reconozca la bala

        }
        if (Time.time - tiempoUltimoUso > tiempoInactivoParaRegresar)
        {
            ActivarPersonajeSinArma();
            ArmaMosquete = false;//para que no reconozca la bala
        }

        Movimiento();
        Salto();
        Ataque();
     
        DispararMosquete();
        
    }
    void Movimiento()
    {
        float Movx = Input.GetAxis("Horizontal");
        float Movz = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(Movx, 0, Movz).normalized;
        float Magnitud = Mathf.Clamp01(direction.magnitude);

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            Speed = SpeedRun;
            Magnitud /= 0.5f;
        }
        else
        {
            Speed = SpeedWalk;
        }

        animator.SetFloat("Input Magnitude", Magnitud, 0.05f, Time.deltaTime);



        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;//detecta el agunlo
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref SensivitySmooth, VelocitySmooth);//agrega el suavizado
            transform.rotation = Quaternion.Euler(0, angle, 0);//el personaje girara

            Vector3 movDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; //sumara el vector de antes mas el giro de la camara
            Controller.Move(movDir.normalized * Speed * Time.deltaTime);
        }
    }

    void Salto()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, groundMask);

        if (isGrounded && VelocidadGravedad.y < 0)
        {
            VelocidadGravedad.y = -2f;
            animator.SetBool("isGrounded", true);
            isGround = true;
            animator.SetBool("isJumping", false);
            isJump = false;

        }
        else
        {
            animator.SetBool("isGrounded", false);
            isGround = false;

            if (isJump && VelocidadGravedad.y < 0)
            {
                animator.SetBool("isFalling", true);
            }
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            VelocidadGravedad.y = Mathf.Sqrt(HeightJump * -2f * gravedad);
            animator.SetBool("isJumping", true);
            isJump = true;
        }

        VelocidadGravedad.y += gravedad * Time.deltaTime;
        Controller.Move(VelocidadGravedad * Time.deltaTime);

    }

    void Ataque()
    {
        if (!enConversacion && Input.GetMouseButtonDown(0)) //if (animacionNpc != null && !animacionNpc.enConversacion && Input.GetMouseButtonDown(0)) "Si  está asignado, el jugador NO está en conversación con el NPC, y el botón izquierdo del ratón fue presionado, entonces ejecuta lo que sigue"
        {
            animator.SetBool("Attack", true);

            if (ArmaLanza)
            {
                EsferaLaza.SetActive(true);
            }
            else if (ArmaEspada)
            {
                EsferaEspada.SetActive(true);
            }

            EsferaAtaque.SetActive(true);
            tiempoUltimoUso = Time.time;
        }
        else
        {
            animator.SetBool("Attack", false);
            EsferaAtaque.SetActive(false);
            EsferaLaza.SetActive(false);
            EsferaEspada.SetActive(false);

        }
    }

    void ActivarPersonajeSinArma()
    {
        personajeSinArma.SetActive(true);
        personajeConLanza.SetActive(false);
        personajeConEspada.SetActive(false);
        personajeMosquete.SetActive(false);

        animator = personajeSinArma.GetComponentInChildren<Animator>();
        tiempoUltimoUso = Time.time;
    }
    void ActivarPersonajeLanza()
    {
        personajeSinArma.SetActive(false);
        personajeConLanza.SetActive(true);
        personajeConEspada.SetActive(false);
        personajeMosquete.SetActive(false);

        ArmaMosquete = false; //Desactivara el mosquete y no lo dectara para sacar la bala
        animator = personajeConLanza.GetComponentInChildren<Animator>();
        tiempoUltimoUso = Time.time;
    }
    void ActivarPersonajeEspada()
    {
        personajeSinArma.SetActive(false);
        personajeConLanza.SetActive(false);
        personajeConEspada.SetActive(true);
        personajeMosquete.SetActive(false);

        animator = personajeConEspada.GetComponentInChildren<Animator>();
        tiempoUltimoUso = Time.time;
    }

    void ActivarPersonajeMosquete()
    {
        personajeSinArma.SetActive(false);
        personajeConLanza.SetActive(false);
        personajeConEspada.SetActive(false);
        personajeMosquete.SetActive(true);

        animator = personajeMosquete.GetComponentInChildren<Animator>();
        tiempoUltimoUso = Time.time;


    }
    void DispararMosquete()
    {
        if (ArmaMosquete && Input.GetMouseButtonDown(0))
        {
            if (instanciaBala != null)
            {
                instanciaBala.dispara();
            }
        }
    }
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