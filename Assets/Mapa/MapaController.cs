using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapaController : MonoBehaviour
{
    [Header("Elementos gráficos")]
    [SerializeField] Transform PlayerIcon;
    [SerializeField] Transform Mapa;
    [SerializeField] Transform PlayerPosition;

    /*[Space]
    [Header("Elementos gráficos")]*/



    private void Update()
    {

        PlayerIcon.rotation = Quaternion.Euler(0f,0f,-PlayerPosition.eulerAngles.y);
        //        imagen2D.rotation = Quaternion.Euler(0f, 0f, zRotation);

        Mapa.localPosition = new Vector3(-PlayerPosition.position.x, -PlayerPosition.position.z,0);

    }

    // Start is called before the first frame update

}
