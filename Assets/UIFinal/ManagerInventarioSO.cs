using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManagerInventarioSO : MonoBehaviour
{
    [Header("Scriptable Objects")]
    [SerializeField] ItemUI[] ItemInventario;

    ItemUI ObjetoSeleccionado;
    
    [Header("Elementos de la UI")]
    [SerializeField] Image ImagenFondo;
    [SerializeField] TMP_Text NombreItem;
    [SerializeField] TMP_Text DescripcionItem;
    [SerializeField] TMP_Text TeclaItem;


    public void MostrarObjeto(int ID_Item)
    {

        foreach(ItemUI item in ItemInventario)
        {
            if (item.id == ID_Item)
            {
                ObjetoSeleccionado = item;
                break;
            }
        }

        if(ObjetoSeleccionado == null)
        {
            return;
        }

        ImagenFondo.sprite = ObjetoSeleccionado.icon;
        NombreItem.text = ObjetoSeleccionado.ItemName;
        DescripcionItem.text = ObjetoSeleccionado.DescripcionInventario;
        TeclaItem.text = $"Tecla para usarlo: {ObjetoSeleccionado.TeclaActivar}";

    }

}
