using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class movimientoEnemigo2 : MonoBehaviour
{
    public NavMeshAgent Agent2;
    public Transform pointPlayer;
    public float radio2;
    public float radioAtaque2;
    public Animator animacionEnemigo2;

   // public GameObject objeto2;
    public GameObject enemigo2;
    public int saludEnemi2;
    [SerializeField] GameObject[] objetos2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NaveMeshMover2();
    }
    public void NaveMeshMover2()
    {
        float rango2 = Vector3.Distance(pointPlayer.position, transform.position);

        if (rango2 <= radio2)
        {
            Objetivo2();
            Agent2.SetDestination(pointPlayer.position);
            animacionEnemigo2.SetBool("caminar", true);
            animacionEnemigo2.SetBool("golpe2", false);
            animacionEnemigo2.SetBool("golpe3", false);
            animacionEnemigo2.SetBool("golpe4", false);
            Agent2.speed = 2.5f;

            if (rango2 <= radioAtaque2)
            {
                Agent2.speed = 0f;

                animacionEnemigo2.SetBool("caminar", false);
                animacionEnemigo2.SetBool("golpe2", false);
                animacionEnemigo2.SetBool("golpe3", false);
                animacionEnemigo2.SetBool("golpe4", false);

                animacionEnemigo2.SetBool("atacar", true);
                animacionEnemigo2.SetBool("atacar1", true);
                

            }
            else
            {
                Agent2.speed = 2.5f;

                animacionEnemigo2.SetBool("caminar", true);

                animacionEnemigo2.SetBool("atacar", false);
                animacionEnemigo2.SetBool("atacar1", false);


            }
        }
        else
        {
            animacionEnemigo2.SetBool("caminar", false);
            Agent2.speed = 0f;
        }
    }
    void Objetivo2()
    {
        Vector3 radio = (pointPlayer.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(radio.x, 0, radio.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 1f);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radio2);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radioAtaque2);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "simitarra")
        {
            saludEnemi2 = saludEnemi2 - 90;
            animacionEnemigo2.SetBool("golpe2", true);
        }
      
        if (collision.transform.tag == "mosquete")
        {
            saludEnemi2 = saludEnemi2 - 47;
            animacionEnemigo2.SetBool("golpe3", true);
        }
        
        if (collision.transform.tag == "lanza")
        {
            saludEnemi2 = saludEnemi2 - 60;
            animacionEnemigo2.SetBool("golpe4", true);
        }
        
        if (saludEnemi2 <= 0)
        {
            Agent2.speed = 0f;
            radio2 = 0f;
            Destroy(gameObject, 7f);
            animacionEnemigo2.SetBool("derrota2", true);
            Posicion2();
        }
    }
    public void Posicion2()
    {
        int RangoCosas2 = Random.Range(0, objetos2.Length);
        Instantiate(objetos2[RangoCosas2], enemigo2.transform.position, enemigo2.transform.rotation);
    }
}
