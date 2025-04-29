using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventarioManager : MonoBehaviour
{
    public static inventarioManager Instance;
    public List<Objetos> objetos = new List<Objetos>();

    public Transform ItemContent;
    public GameObject InventarioObjetos;

    public controladorDeObjetosEnInventario[] inventarioDeObjetos;

    private void Awake()
    {
        Instance = this;
    }

     public void Agregar(Objetos objeto)
    {
        objetos.Add(objeto);
    }

    public void Quitar(Objetos objeto)
    {
        objetos.Remove(objeto);
    }

    public void ListaObjetos()
    {
        foreach (Transform objeto in ItemContent)
        {
            Destroy(objeto.gameObject);
        }
        foreach (var objeto in objetos)
        {
            GameObject obj = Instantiate(InventarioObjetos, ItemContent);

            var nombreObjetos = obj.transform.Find("textoObjetos").GetComponent<Text>();
            var iconos = obj.transform.Find("imagenObjeto").GetComponent<Image>();

            nombreObjetos.text = objeto.nombreObjeto;
            iconos.sprite = objeto.icono;
        }

        objetoEnInventario();
    }

    public void objetoEnInventario()
    {
        inventarioDeObjetos = ItemContent.GetComponentsInChildren<controladorDeObjetosEnInventario>();
        
        for (int i = 0; i < objetos.Count; i++)
        {
            inventarioDeObjetos[i].agregarObjeto(objetos[i]);
        }
    }
}
