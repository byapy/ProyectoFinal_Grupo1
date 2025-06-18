using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCharacterCtrl : MonoBehaviour
{
    public CharacterController Controlador;
    public GameObject Personaje;
    public Transform GroundCheck;
    public float Velocidad = 5, Gravedad = -9.81f, GroundDistance = 0.4f, HeightJump = 1.3f; 
    //public int Monedas, Vida, Puntos;
    public Vector3 Escala = new(1, 1, 1), Rotacion = new(4,2,1), VelocidadGravedad;
    public LayerMask groundMask;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        Controlador = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Para que verifique si el objeto está o no tocando el suelo y no aumente la velocidad en Y constantemente
        isGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, groundMask);
        if (isGrounded && VelocidadGravedad.y < 0)
        {
            VelocidadGravedad.y = -2f;
        }
        /***********************************************************************/

        float MovX = Input.GetAxis("Horizontal"), MovZ = Input.GetAxis("Vertical");

        //transform right, up y forward tienen un valor de 1. Mueve al personaje en X y Z
        //Para correr
        if (Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift)) Velocidad = 10;
        else Velocidad = 5;

        Vector3 Mover = (transform.right * MovX) + (transform.forward * MovZ);
        Controlador.Move(Mover * Velocidad * Time.deltaTime);
        
        //Para saltar y poder caer después
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            VelocidadGravedad.y = Mathf.Sqrt(HeightJump * -2f * Gravedad);
        }

        //Cálculo de la gravedad, mueve solo en Y
        VelocidadGravedad.y += Gravedad * Time.deltaTime;
        Controlador.Move(VelocidadGravedad * Time.deltaTime);
    }

}
