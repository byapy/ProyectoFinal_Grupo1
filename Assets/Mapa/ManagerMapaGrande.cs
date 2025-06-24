using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerMapaGrande : MonoBehaviour
{

    [Header("Las flechas del Player")]
    [SerializeField] Transform FlechaMapaGrande;
    [SerializeField] Transform FlechaMinimapa;
    [Space]
    [Header("El Mapa Actual")]
    [SerializeField] Image MapaGrande;
    [SerializeField] Image MapaChiquito;

    private void Start()
    {
        if (FlechaMinimapa != null || MapaChiquito != null)
        {
            FlechaMapaGrande.localPosition = new Vector3(FlechaMinimapa.localPosition.x, FlechaMinimapa.localPosition.y);
            FlechaMapaGrande.localRotation = FlechaMinimapa.localRotation;

            MapaGrande.sprite = MapaChiquito.sprite;
        }
    }

    void Update()
    {
        if(FlechaMinimapa != null || MapaChiquito != null)
        { 
            FlechaMapaGrande.localPosition = new Vector3(FlechaMinimapa.localPosition.x, FlechaMinimapa.localPosition.y);      
            FlechaMapaGrande.localRotation = FlechaMinimapa.localRotation;

            MapaGrande.sprite = MapaChiquito.sprite;
        }
    }
}
