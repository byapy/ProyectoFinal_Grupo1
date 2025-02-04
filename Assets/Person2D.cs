using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person2D : MonoBehaviour
{
    public CharacterController controller;
    public float speed;
    public float rotacionSpeed;

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
        float MovX = Input.GetAxis("Horizontal");        

        Vector3 direction = new Vector3(0, 0, MovX).normalized;
        float Magnitud = Mathf.Clamp01(direction.magnitude);

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            Magnitud /= 0.5f;
        }

        animator.SetFloat("Input Magnitud", Magnitud, 0.05f, Time.deltaTime);

        if (direction != Vector3.zero)
        {
            // transform.forward = direction;
            Quaternion toRotation = Quaternion.LookRotation(direction,Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotacionSpeed * Time.deltaTime);
            controller.Move(direction.normalized * speed * Time.deltaTime);

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

            if (isJump && VelocidadGravedad.y < 0)
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
}
