using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class movimientoEnemigo : MonoBehaviour
{
    public static movimientoEnemigo Instance;
    public NavMeshAgent Agent;
    public Transform pointPlayer;
    public float radio;
    public float radioAtaque;
    public Animator animacionEnemigo;

    //public GameObject objeto;
    public GameObject enemigo1;

    [SerializeField] GameObject[] objetos;

    //Para la barra flotante y los números de daño
    bool IsAlive;
    BarraVidaEnemigo barraVida;
    [SerializeField] private float saludEnemigo;
    public float MaxSalud;

    private void Awake()
    {
        barraVida = GetComponentInChildren<BarraVidaEnemigo>();
        Instance = this;
    }
    void Start()
    {
        IsAlive = true;
        //Para que se reinicien los valor por si se recarga la escena
        barraVida.ActualizarBarra(saludEnemigo, MaxSalud);

        saludEnemigo = MaxSalud;
        animacionEnemigo = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        NavMeshMovimiento();
        RevisarVida();
    }

    public void ReceivedDamage(float Damage)
    {
        saludEnemigo -= Damage;
        //animacionEnemigo.SetBool("golpess", true);
        RevisarVida();
    }
    public void NavMeshMovimiento()
    {
        float rango = Vector3.Distance(pointPlayer.position, transform.position);

        if (rango <= radio)
        {
            Objetivo();
            Agent.SetDestination(pointPlayer.position);
            animacionEnemigo.SetBool("correr", true);
            
            Agent.speed = 3f;
            
            if (rango <= radioAtaque)
            {
                Agent.speed = 0f;

                animacionEnemigo.SetBool("correr", false);
                

                animacionEnemigo.SetBool("ataque", true);
                animacionEnemigo.SetBool("patada", true);

            }
            else
            {
                animacionEnemigo.SetBool("ataque", false);
                animacionEnemigo.SetBool("patada", false);
                animacionEnemigo.SetBool("correr", true);
                animacionEnemigo.SetBool("golpess", false);
            }
        }
        else
        {
            animacionEnemigo.SetBool("correr", false);
            Agent.speed = 0f;
        }
    }
    void Objetivo()
    {
        Vector3 radio = (pointPlayer.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(radio.x, 0, radio.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 1f);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radio);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radioAtaque);
    }
    //ONCOLLISION NO SE USA POR EL MOMENTO
    public void OnCollisionEnter(Collision collision)
    {
        /*if (collision.transform.tag == "simitarra")
        {
            saludEnemigo = saludEnemigo - 90;
            

                  
        }
        
        if (collision.transform.tag == "mosquete")
        {
            saludEnemigo = saludEnemigo - 47;
            animacionEnemigo.SetBool("golpess", true);
        }
       
        if (collision.transform.tag == "lanza")
        {
            saludEnemigo = saludEnemigo - 60;
            animacionEnemigo.SetBool("golpess", true);
        }*/
        
    }
    private void RevisarVida()
    {
        
        barraVida.ActualizarBarra(saludEnemigo, MaxSalud); 

        if (saludEnemigo <= 0 && IsAlive == true)
        {
            Agent.speed = 0f;
            radio = 0f;
            Destroy(gameObject, 5f);
            animacionEnemigo.SetBool("derrota", true);
          //  Rigidbody rigidbody = GetComponent<Rigidbody>();
           // rigidbody.gameObject.SetActive(false);
            IsAlive = false;

            Posicion();
        }
    }
    public void Posicion()
    {
        int RangoCosas = Random.Range(0, objetos.Length);
        Instantiate(objetos[RangoCosas], enemigo1.transform.position, Quaternion.identity);
    }
}
