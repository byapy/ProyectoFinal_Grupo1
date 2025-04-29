using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (fileName = "New Objeto", menuName = "Objeto")]
public class ObjetosDescripcion : ScriptableObject
{
    public string NombreObjeto;
    public string DescripcionObjeto;
    public int nivelDelObjeto;
    public Sprite IconoObjeto;
    public GameObject modelo3D;
}
