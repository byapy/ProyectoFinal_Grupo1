using UnityEngine;

public class BalaMovimiento : MonoBehaviour
{
    public float velocidad = 40f; // Velocidad de la bala
    private Vector3 direccion;   // Dirección hacia el jugador
    public float tiempoDeVida = 5f; // Tiempo que la bala tarda en destruirse

    private ParticleSystem particulaBala; // Para referirse al sistema de partículas

    void Start()
    {
        // Obtener la referencia al sistema de partículas
        particulaBala = GetComponent<ParticleSystem>();
    }

    public void Inicializar(Vector3 objetivo)
    {
        direccion = (objetivo - transform.position).normalized; // Apunta hacia el jugador
        Invoke("DestruirBala", tiempoDeVida); // Llama a DestruirBala() después de 3 segundos
    }

    void Update()
    {
        // Mueve la bala en la dirección deseada a la velocidad establecida
        transform.position += direccion * velocidad * Time.deltaTime;
    }

    private void DestruirBala()
    {
        // Detenemos las partículas antes de destruir la bala
        if (particulaBala != null)
        {
            particulaBala.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }

        Destroy(gameObject, 0.5f); // Espera un poco para destruir la bala y dar tiempo a que las partículas desaparezcan
    }

    private void OnTriggerEnter(Collider other)
    {
        // Aquí puedes poner qué pasa cuando la bala toca algo
        if (other.CompareTag("Player"))
        {
            // Lógica de daño al jugador
            Destroy(gameObject); // Destruye la bala al impactar
        }
        else if (other.CompareTag("Pared") || other.CompareTag("Obstaculo"))
        {
            Destroy(gameObject); // Destruye si choca con otra cosa
        }
    }
}
