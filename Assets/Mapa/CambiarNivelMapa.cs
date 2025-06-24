using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambiarNivelMapa : MonoBehaviour
{

    [SerializeField] Image ImgMapa;
    [SerializeField] Sprite[] MapasImagenes = new Sprite[3];
    [SerializeField] Transform PosicionPlayer;

    void Update()
    {
        if(PosicionPlayer.position.y >= 0f && PosicionPlayer.position.y <= 44f)
        {
            ImgMapa.sprite = MapasImagenes[0];
        }
        else if (PosicionPlayer.position.y >= 45f && PosicionPlayer.position.y <= 59f)
        {
            ImgMapa.sprite = MapasImagenes[1];
        }
        else if (PosicionPlayer.position.y >= 60f)
        {
            ImgMapa.sprite = MapasImagenes[2];
        }
    }
}
