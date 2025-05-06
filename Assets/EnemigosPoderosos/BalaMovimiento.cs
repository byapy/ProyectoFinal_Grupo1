using UnityEngine;

public class BalaMovimiento : MonoBehaviour
{
    public float velocidad = 40f; 
    private Vector3 direccion; 
    public float tiempoDeVida = 3f; 

    private ParticleSystem particulaBala; 

    void Start()
    {
       
        particulaBala = GetComponent<ParticleSystem>();
    }

    public void Inicializar(Vector3 objetivo)
    {
        direccion = (objetivo - transform.position).normalized; 
        Invoke("DestruirBala", tiempoDeVida); 
    }

    void Update()
    {
        transform.position += direccion * velocidad * Time.deltaTime;
    }

    private void DestruirBala()
    {
        if (particulaBala != null)
        {
            particulaBala.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }

        Destroy(gameObject, 0.5f); 
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {
            StatsPlayer.Instance.ReceivedDamage(MaestraNegra.Instance.DañoD);
            Destroy(gameObject); 
        }
        
    }
}
