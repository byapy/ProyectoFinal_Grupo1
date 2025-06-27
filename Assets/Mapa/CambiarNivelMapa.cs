using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambiarNivelMapa : MonoBehaviour
{

    [SerializeField] Image ImgMapa;
    [SerializeField] Sprite[] MapasImagenes = new Sprite[3];
    [SerializeField] Transform PosicionPlayer;
    [SerializeField] GameObject[] NivelesActivos = new GameObject[3];
    [SerializeField] GameObject[] NivelesActivosGrandes = new GameObject[3];

    void Update()
    {
        if(PosicionPlayer.position.y >= 0f && PosicionPlayer.position.y <= 44f)
        {
            ImgMapa.sprite = MapasImagenes[0];
            
            NivelesActivos[0].SetActive(true);
            NivelesActivos[1].SetActive(false);
            NivelesActivos[2].SetActive(false);

            NivelesActivosGrandes[0].SetActive(true);
            NivelesActivosGrandes[1].SetActive(false);
            NivelesActivosGrandes[2].SetActive(false);


        }
        else if (PosicionPlayer.position.y >= 45f && PosicionPlayer.position.y <= 59f)
        {
            ImgMapa.sprite = MapasImagenes[1];
            NivelesActivos[0].SetActive(false);
            NivelesActivos[1].SetActive(true);
            NivelesActivos[2].SetActive(false);

            NivelesActivosGrandes[0].SetActive(false);
            NivelesActivosGrandes[1].SetActive(true);
            NivelesActivosGrandes[2].SetActive(false);
        }
        else if (PosicionPlayer.position.y >= 60f)
        {
            ImgMapa.sprite = MapasImagenes[2];

            NivelesActivos[0].SetActive(false);
            NivelesActivos[1].SetActive(false);
            NivelesActivos[2].SetActive(true);

            NivelesActivosGrandes[0].SetActive(false);
            NivelesActivosGrandes[1].SetActive(false);
            NivelesActivosGrandes[2].SetActive(true);
        }
    }
}
