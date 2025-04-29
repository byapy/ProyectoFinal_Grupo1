using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCharacterController : MonoBehaviour
{
    public CharacterController Controller;
    public float velocidad;

    public Vector3 VelocidadGravedad;
    public float gravedad = -9.81f;

    public Transform GroundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;
    public bool chequeo;

    public float HeightJump;

    public Camera fpsCamera;
    public float Range;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, groundMask);

       if(isGrounded && VelocidadGravedad.y < 0)
        {
            VelocidadGravedad.y = -2f;
        }

        float movx = Input.GetAxis("Horizontal");
        float movz = Input.GetAxis("Vertical");

        Vector3 mover = transform.right * movx + transform.forward * movz;
        Controller.Move(mover * velocidad * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            VelocidadGravedad.y = Mathf.Sqrt(HeightJump * -2f * gravedad);
        }

        VelocidadGravedad.y += gravedad * Time.deltaTime;
        Controller.Move(VelocidadGravedad * Time.deltaTime);       
    }

  





}
