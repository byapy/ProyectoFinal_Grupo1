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
            //Tipoobjeto está solo Arma o Pocion
            //EtiquetaItem están los tags
            switch(item.TipoObjeto.ToString().ToLower())
            {
                case "arma":
                    StatsPlayer.Instance.ActivarArmaNueva(item.EtiquetaItem.ToString().ToLower());
                    Destroy(this.gameObject);
                    break;
                case "pocion":
                    StatsPlayer.Instance.AgregarPocion(item.EtiquetaItem.ToString().ToLower());
                    break;

            }

            ActivarAnimacionesMercader.Instance.VentaBuenaInicio();
            CargarElemenos.Instance.MandarMensaje($"Gracias por tu compra.\nCompraste {item.ItemName} por {item.price} de Oro.");
        }
        else
        {
            ActivarAnimacionesMercader.Instance.VentaMalaInicio();
            CargarElemenos.Instance.MandarMensaje("No tienes suficiente dinero para comprar este objeto.\nVuelve cuando consigas más oro.\nAhora vete de aquí.");
        }


    }
}
