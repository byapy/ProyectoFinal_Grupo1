using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Terminar_Juego : MonoBehaviour
{
    public GameObject CamaraCinematica;
    public GameObject Interfaz;
    public GameObject JugadorL;
    public GameObject Muñeco;
    public Image FadePanel;

    public GameObject Creditos;
    public GameObject Texto;
    public GameObject END;
    public GameObject Activador;
    public GameObject Fondo;


    public float duracionCinematica = 25f;
    public float duracionFade = 2f;

    public bool mostrandoCreditos = false;

    private void Awake()
    {

    }
    void Start()
    {
        JugadorL = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (mostrandoCreditos && Input.GetKeyDown(KeyCode.Escape))
        {
            SalirDeCreditos();
        }
    }
    void SalirDeCreditos()
    {
        Debug.Log("De regreso al Menu principal");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("InicioEcenaFinal");
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
                Muñeco.SetActive(true);
                Destroy(JugadorL);
                Destroy(Interfaz);
                Cursor.visible = false;

                CamaraCinematica.SetActive(true);
                Debug.Log("CinematicaCorriendo");
                StartCoroutine(EsperarYHacerFade());

            
        }

    }
    IEnumerator EsperarYHacerFade()
    {
        yield return new WaitForSeconds(duracionCinematica);
        float elapsed = 0f;
        Color color = FadePanel.color;

        while (elapsed < duracionFade)
        {
            elapsed += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsed / duracionFade);
            FadePanel.color = color;
            yield return null;
        }
        Creditos.SetActive(true);
        mostrandoCreditos = true;
        LimpiarEscena();


    }
    void LimpiarEscena()
    {
        GameObject[] todosLosObjetos = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in todosLosObjetos)
        {
            // No desactivar el objeto de créditos ni el panel de fade, ni objetos inactivos para evitar errores
            if (obj != Creditos && obj != END && obj != Activador && obj != CamaraCinematica && obj != Fondo && obj != Texto) 
            {
                Destroy(obj);

            }
        }
    }   
}
