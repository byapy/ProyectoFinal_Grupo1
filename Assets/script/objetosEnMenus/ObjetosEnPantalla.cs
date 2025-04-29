using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjetosEnPantalla : MonoBehaviour
{
    public ObjetosDescripcion anilloFuerza;
    public ObjetosDescripcion anilloMagia;
    public ObjetosDescripcion armadura;
    public ObjetosDescripcion escudo;

    public Text TextoNombre;
    public Text TextoDescripcion;
    public Text TextoNivel;
    public Image IconoDeObjeto;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void descripcionAnilloFuerza()
    {
        TextoNombre.text = anilloFuerza.NombreObjeto;
        TextoDescripcion.text = anilloFuerza.DescripcionObjeto;
        TextoNivel.text = "Nivel: " + anilloFuerza.nivelDelObjeto;
        IconoDeObjeto.sprite = anilloFuerza.IconoObjeto;
    }

    public void descripcionAnilloMagia()
    {
        TextoNombre.text = anilloMagia.NombreObjeto;
        TextoDescripcion.text = anilloMagia.DescripcionObjeto;
        TextoNivel.text = "Nivel: " + anilloMagia.nivelDelObjeto;
        IconoDeObjeto.sprite = anilloMagia.IconoObjeto;
    }

    public void descripcionArmadura()
    {
        TextoNombre.text = armadura.NombreObjeto;
        TextoDescripcion.text = armadura.DescripcionObjeto;
        TextoNivel.text = "Nivel: " + armadura.nivelDelObjeto;
        IconoDeObjeto.sprite = armadura.IconoObjeto;
    }

    public void descripcionEscudo()
    {
        TextoNombre.text = escudo.NombreObjeto;
        TextoDescripcion.text = escudo.DescripcionObjeto;
        TextoNivel.text = "Nivel: " + escudo.nivelDelObjeto;
        IconoDeObjeto.sprite = escudo.IconoObjeto;
    }
}
