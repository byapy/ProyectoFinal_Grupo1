using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CargarElemenos : MonoBehaviour
{
    public static CargarElemenos Instance;
    public List<ItemUI> ItemsDisponibles;
    //public Text TxtNombre, TxtDescripcion, TxtPrecio;
    //public Image IconoItem;
    public GameObject PrefabBotonItem, CajaDialogo;
    public Transform ContenedorItems;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        ListItems();
    }

    private void ListItems()
    {
        //Meterle valores acorder al SO en el bot�n
        
        foreach(ItemUI objeto in ItemsDisponibles)
        {

            if(objeto.ItemName.ToLower() == "espada" && StatsPlayer.TieneEspada)
            {
                 continue;
            }

            if (objeto.ItemName.ToLower() == "mosquete" && StatsPlayer.TieneMosquete)
            {
                continue;
            }
            
            //Instanciar el bot�n en una variable
            GameObject obj = Instantiate(PrefabBotonItem, ContenedorItems);

            //Asigne los valores a sus posiciones adecuadas
            var itemName = obj.transform.Find("itemName").GetComponent<Text>();

            var itemDescription = obj.transform.Find("itemDescription").GetComponent<Text>();

            var itemIcon = obj.transform.Find("itemIcon").GetComponent<Image>();

            var itemValue = obj.transform.Find("itemPrecio").GetComponent<Text>();

            //Asignar los valores a los campos del bot�n

            itemName.text = objeto.ItemName;
            itemIcon.sprite = objeto.icon;
            itemValue.text = objeto.price + " Oro";
            

            switch (objeto.TipoObjeto.ToString())
            {
                case "Pocion":
                    switch (objeto.EtiquetaItem.ToString().ToLower())
                    {
                        case "vida":
                            itemDescription.text = objeto.Descripcion + "\nEsta poci�n te cura <b>" + objeto.value.ToString()+"</b> de da�o";
                            break;

                        default:
                            itemDescription.text = objeto.Descripcion + "\nEsta poci�n dura <b>" + objeto.value.ToString() + "</b> segundos";
                            break;
                    }
                    break;

                case "Arma":
                    itemDescription.text = objeto.Descripcion + "\nEste objeto hace un da�o de <b>" + objeto.value.ToString()+"</b>";
                    break;
            }

            TiendaItemController.Instance.SetItem(objeto);
        }
    }
    public void ReiniciarMensaje()
    {
        var TxtDialogo = CajaDialogo.transform.Find("Dialogo").GetComponent<Text>();
        TxtDialogo.text = "Oh, t� de nuevo.\nBienvenido, �En qu� te puedo ayudar?";

    }

    public void MandarMensaje(string MensajeVenta)
    {
        CajaDialogo.transform.gameObject.SetActive(true);
        //Nombre Dialogo
        var TxtDialogo = CajaDialogo.transform.Find("Dialogo").GetComponent<Text>();
        TxtDialogo.text = MensajeVenta;
    }



}
