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
        bool puedeComprar;
        puedeComprar = StatsPlayer.Instance.PuedeComprar(item.price);

        if (puedeComprar)
        {
            //Tipoobjeto está solo Arma o Pocion
            //EtiquetaItem están los tags
            switch(item.TipoObjeto.ToString().ToLower())
            {
                case "arma":
                    StatsPlayer.Instance.ActivarArmaNueva(item.EtiquetaItem.ToString().ToLower());
                    UIController.Instance.ActivarArmaNueva(item.EtiquetaItem.ToString().ToLower());
                    Destroy(this.gameObject);
                    break;

                case "pocion":
                    //Limitar la compra de pociones
                    bool TieneEspacio = false;
                    switch (item.EtiquetaItem.ToString().ToLower())
                    {
                        case "vida":
                            if (StatsPlayer.PPociones[0] + 1 <= 15) TieneEspacio = true;
                            break;

                        case "defensa":
                            if (StatsPlayer.PPociones[1] + 1 <= 15) TieneEspacio = true;
                            break;

                        case "ataque":
                            if (StatsPlayer.PPociones[2] + 1 <= 15) TieneEspacio = true;
                            break;

                    }

                    if (TieneEspacio) StatsPlayer.Instance.AgregarPocion(item.EtiquetaItem.ToString().ToLower());
                    else
                    {
                        ActivarAnimacionesMercader.Instance.VentaMalaInicio();
                        CargarElemenos.Instance.MandarMensaje("Ya tienes muchas pociones de este tipo.\nVuelve cuando hayas usado algunas de ellas.");
                        return;
                    }
                    break;

            }

            

            StatsPlayer.Instance.QuitarDinero(item.price);
            ActivarAnimacionesMercader.Instance.VentaBuenaInicio();
            CargarElemenos.Instance.MandarMensaje($"¡Gracias por tu compra!\nTengo más cosas que te pueden interesar...");
        }
        else
        {
            ActivarAnimacionesMercader.Instance.VentaMalaInicio();
            CargarElemenos.Instance.MandarMensaje("No tienes suficiente dinero para comprar esto.\nVuelve cuando consigas <b>más oro</b>.\n¡Ahora vete de aquí!");
        }


    }
}
