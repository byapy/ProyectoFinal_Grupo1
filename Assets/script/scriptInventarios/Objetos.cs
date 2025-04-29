using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Itme/Crear nuevo Objeto")]
public class Objetos : ScriptableObject
{
    public int Id;
    public string nombreObjeto;
    public int valor;
    public Sprite icono;
    public tipoObjeto TiposObjeto;

    public enum tipoObjeto
    {
        arma1,
        arma2,
        energia
    }
}

