using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NivelTrigger : MonoBehaviour
{
    public int nivelId;
    [SerializeField] GameObject GemaGraficos;
    public PlayerController playerController;

    public GameObject gemaSprite;

    private void Awake()
    {
        if (!Mecanica_Recoleccion.NivelSuperado[nivelId - 1])
        {
            GemaGraficos.SetActive(true);
        }
        else Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerController != null)
            {
                if (nivelId > PlayerController.nivelProgreso)
                {
                    playerController.AumentarProgreso();
                    PlayerController.nivelProgreso = nivelId;
                    Debug.Log($"Nivel {nivelId} asignado al jugador");
                }
            }
            //Algo que cuando choque se active mi animacion
            LeanTween.scale(gemaSprite, new Vector3(0.7f, 0.7f, 0.7f), 0.2f).setDelay(0.5f).setEase(LeanTweenType.easeOutBack);
            LeanTween.moveLocal(gemaSprite, new Vector3 (842f,432f, 0f),0.8f).setDelay(0.6f).setEase(LeanTweenType.easeOutBack).setOnComplete(() =>
            {
                Destroy(gemaSprite);
            });
        }
        

    }
    public int NivelSuperado()
    {
        return nivelId - 1;
    }
}
