using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed;

    public float VelocitySmooth = 0.1f;
    public float SensivitySmooth;

    public Transform cam;

    public Vector3 VelocidadGravedad;
    public float gravedad = -9.81f;
    public bool isGrounded;
    public Transform GroundCheck;
    public float GroundDistance;
    public LayerMask groundMask;
    public bool chequeo;    

    public float HeightJump;

    public Animator animator;
    public bool isJump;
    public bool IsGround;
    public bool IsFalling;

    public GameObject EsferaAttack;
        

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    
    void Update()
    {
        Movimiento();
        Salto();
        Attack();
    }

    void Movimiento()
    {
        float MovX = Input.GetAxis("Horizontal");
        float MovZ = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(MovX, 0, MovZ).normalized;
        float Magnitud = Mathf.Clamp01(direction.magnitude);

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            Magnitud /= 0.5f;
        }

        animator.SetFloat("Input Magnitud", Magnitud, 0.05f, Time.deltaTime);


        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y; //detectar el jángulo en el que gira
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref SensivitySmooth, VelocitySmooth); // le agrega un suavizado para que el ángulo "gire mas despacio"
            transform.rotation = Quaternion.Euler(0, angle, 0); //decimos al pesonaje que gire en el eje y

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
       
    }
    void Salto()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, groundMask);

        if (isGrounded && VelocidadGravedad.y < 0)
        {
            VelocidadGravedad.y = -2f;
            animator.SetBool("IsGrounded", true);
            IsGround = true;
            animator.SetBool("IsJumping", false);
            isJump = false;
                    }
        else
        {
            animator.SetBool("IsGrounded", false);
            IsGround = false;

            if(isJump && VelocidadGravedad.y < 0)
            {
                animator.SetBool("IsFalling", true);

            }
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            VelocidadGravedad.y = Mathf.Sqrt(HeightJump * -2f * gravedad);
            animator.SetBool("IsJumping", true);
            isJump = true;
        }

        VelocidadGravedad.y += gravedad * Time.deltaTime;
        controller.Move(VelocidadGravedad * Time.deltaTime);
    }

    void Attack()
    {
        if ( Input.GetMouseButtonDown(0))
        {
            animator.SetBool("Attack", true);
            EsferaAttack.SetActive(true);
        }
        else
        {
            animator.SetBool("Attack", false);
            EsferaAttack.SetActive(false);
        }
    }
}
