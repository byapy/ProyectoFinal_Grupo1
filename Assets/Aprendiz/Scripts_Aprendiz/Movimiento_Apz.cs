using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_Apz : MonoBehaviour
{
    public CharacterController Controller;
    public float Speed;

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

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        Movimiento();
        Salto();

    }
    void Movimiento()
    {
        float Movx = Input.GetAxis("Horizontal");
        float Movz = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(Movx, 0, Movz).normalized;
        float Magnitud = Mathf.Clamp01(direction.magnitude);

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            Magnitud /= 0.5f;
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
}