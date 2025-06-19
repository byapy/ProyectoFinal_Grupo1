using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Name Item", menuName = "Item/Create New Item")]
public class ItemUI : ScriptableObject 
{
    public int id;
    public string ItemName, Descripcion;
    public int value, price;
    public Sprite icon;
    public ItemTag EtiquetaItem;
    public TipoItem TipoObjeto;

    [TextArea(3, 10)]
    public string DescripcionInventario;
    public string TeclaActivar;

    public enum ItemTag
    {
        Vida, Defensa, Ataque, Mosquete, Espada, Lanza
    }

    public enum TipoItem
    {
        Arma, Pocion
    }
}
