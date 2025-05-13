using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiendaItemController : MonoBehaviour
{

    public static TiendaItemController Instance;
    public ItemUI item;

    private void Awake()
    {
        Instance = this;
    }

    public void SetItem(ItemUI itemComprado)
    {
        item = itemComprado;
    }

    public void PurchaseItem()
    {
        bool pudoComprar;
        pudoComprar = StatsPlayer.Instance.QuitarDinero(item.price);

        if (pudoComprar)
        {
            CargarElemenos.Instance.MandarMensaje($"Gracias por tu compra. Compraste {item.ItemName} por {item.price} de Oro.");
        }
        else
        {
            CargarElemenos.Instance.MandarMensaje("No tienes suficiente dinero para comprar este objeto.\nVuelve cuando consigas más oro.\nAhora vete de aquí.");
        }


    }
}
