using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirAlPlayer : MonoBehaviour
{
    enum TipoDeSeguidor
    {
        Camara,
        Icono
    }

    [SerializeField] Transform UbicacionPlayer;
    [SerializeField] TipoDeSeguidor TipoFollower;

    // Update is called once per frame
    void Update()
    {
        switch(TipoFollower)
        {
            case TipoDeSeguidor.Camara:
                CamaraSigueAlPlayer();
                break;
            case TipoDeSeguidor.Icono:
                IconoSigueAlPlayer();
                break;
        }
    }

    void CamaraSigueAlPlayer()
    {
        //Se mueve en X(Derecha) y Y(arriba)
        transform.position = new Vector3(UbicacionPlayer.position.x, transform.position.y ,UbicacionPlayer.position.z);

    }

    void IconoSigueAlPlayer()
    {
        //Se mueve en X(Derecha) y Y(arriba)
        transform.position = new Vector3(UbicacionPlayer.position.x, transform.position.y, UbicacionPlayer.position.z);

        //rotar en Z a base de la rotación del player en Y
        transform.rotation = Quaternion.Euler(90f, 0, -UbicacionPlayer.rotation.eulerAngles.y);
    }
}
