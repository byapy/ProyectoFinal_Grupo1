using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class movimientoJefe : MonoBehaviour
{
    public static movimientoJefe Instance;
    public NavMeshAgent Agent;
    public Transform pointPlayer;
    public float radioAcercarse;
    public float radioAtaque;
    public float radioAtaqueFuerte;
    public float radioCorrer;
    public Animator animacionJefe;

    barraVidaJefe barraVidaJefe;
    public bool escudoActivado;

    public float MaxSaludJefe;
    [SerializeField] public static float saludJefe = 2500f;

    public void Awake()
    {
        barraVidaJefe = GetComponentInChildren<barraVidaJefe>();
        Instance = this;
    }
    void Start()
    {
        barraVidaJefe.ActualizarBarra(saludJefe, MaxSaludJefe);
        saludJefe = MaxSaludJefe;
    }

    void Update()
    {
        NavMeshMovimiento();
        VidaJefeTotal();
        Debug.Log("salud jefe " + saludJefe);
        
    }

    void AlcanzarJugador()
    {
        Vector3 radio = (pointPlayer.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(radio.x, 0, radio.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 1f);
    }
    public void NavMeshMovimiento()
    {
        float rango = Vector3.Distance(pointPlayer.position, transform.position);

      if (saludJefe >= 1251)
      {
            if (rango <= radioAcercarse)
            {
              AlcanzarJugador();
              Agent.SetDestination(pointPlayer.position);
              animacionJefe.SetBool("caminarJ", true);
              animacionJefe.SetBool("correrJ", false);
              animacionJefe.SetBool("derrotaJ", false);
              Agent.speed = 4f;

              if (rango <= radioAtaque)
              {
                Agent.speed = 0f;
                animacionJefe.SetBool("caminarJ", false);

                animacionJefe.SetBool("ataque1J", true);
                animacionJefe.SetBool("ataque2J", true);
                animacionJefe.SetBool("ataqueFuerJ", true);
                animacionJefe.SetBool("burla", true);
                
                }
              else
              {
                animacionJefe.SetBool("caminarJ", true);

                animacionJefe.SetBool("ataque1J", false);
                animacionJefe.SetBool("ataque2J", false);
                animacionJefe.SetBool("ataqueFuerJ", false);
                animacionJefe.SetBool("burla", false);

                animacionJefe.SetBool("dano", false);
                animacionJefe.SetBool("bloquear", false);
                escudoActivado = false;
              }
              
            }
            else
            {
              animacionJefe.SetBool("caminarJ", false);
              Agent.speed = 0f;
            }
      }

      if (saludJefe <= 1250)
      {
         if (rango <= radioAcercarse)
         {
                AlcanzarJugador();
                Agent.SetDestination(pointPlayer.position);
                animacionJefe.SetBool("caminarJ", true);
                animacionJefe.SetBool("correrJ", false);
                animacionJefe.SetBool("derrotaJ", false);
                Agent.speed = 3.5f;

            if (rango <= radioCorrer)
            {
                AlcanzarJugador();
                Agent.SetDestination(pointPlayer.position);
                animacionJefe.SetBool("correrJ", true);
                animacionJefe.SetBool("caminarJ", false);
                Agent.speed = 6f;

                if (rango <= radioAtaqueFuerte)
                {
                    Agent.speed = 0f;
                    animacionJefe.SetBool("correrJ", false);
                    animacionJefe.SetBool("caminarJ", false);

                    animacionJefe.SetBool("ataqueSalto", true);
                    animacionJefe.SetBool("ataque1J", true);
                    animacionJefe.SetBool("ataque2J", true);
                    animacionJefe.SetBool("ataqueFuerJ", true);
                    animacionJefe.SetBool("burla", true);
                      
                }
                else
                {
                   animacionJefe.SetBool("correrJ", true);
                   animacionJefe.SetBool("caminarJ", false);

                   animacionJefe.SetBool("ataqueSalto", false);
                   animacionJefe.SetBool("ataque1J", false);
                   animacionJefe.SetBool("ataque2J", false);
                   animacionJefe.SetBool("ataqueFuerJ", false);
                   animacionJefe.SetBool("burla", false);

                   animacionJefe.SetBool("dano", false);
                   animacionJefe.SetBool("bloquear", false);
                   escudoActivado = false;
                }

            }
             else
             {
               animacionJefe.SetBool("caminarJ", true);
               animacionJefe.SetBool("correrJ", false);
               Agent.speed = 3.5f;
             }
         }
          else
          {
            animacionJefe.SetBool("caminarJ", false);
            Agent.speed = 0f;
          }
      }

      

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radioAcercarse);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radioCorrer);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioAtaqueFuerte);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radioAtaque);
    }

    public void ReciveDanoJefe(float Damage)
    {
        saludJefe -= Damage;
        animacionJefe.SetBool("dano", true);
        animacionJefe.SetBool("bloquear", true);
        escudoActivado = true;
        VidaJefeTotal();

        if (escudoActivado == true)
        {
            saludJefe = saludJefe - 0;
        }
    }

    public void VidaJefeTotal()
    {
        barraVidaJefe.ActualizarBarra(saludJefe, MaxSaludJefe);
        if (saludJefe <= 0)
        {
            Agent.speed = 0f;
            radioAcercarse = 0f;
            radioCorrer = 0f;
            animacionJefe.SetBool("derrotaJ", true);
            Destroy(gameObject, 10f);

        }
    }
    public void OnCollisionEnter(Collision collision)
    {
    //  if(escudoActivado == false)
      //{
      //  if (collision.transform.tag == "mosquete")
      //  {
       //     saludJefe = saludJefe - 25;
       //     animacionJefe.SetBool("dano", true);
       //     animacionJefe.SetBool("bloquear", true);

      //  }
        //if (collision.transform.tag == "simitarra")
       // {
       //     saludJefe = saludJefe - 100;
       //     
       // }
     // }
    }
}
