using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorDeObjetosEnInventario : MonoBehaviour
{
    public Objetos objeto;
  
    public void removerObjeto() 
    {
        inventarioManager.Instance.Quitar(objeto);
        Destroy(gameObject);
    }

    public void agregarObjeto(Objetos newObjeto)
    {
        objeto = newObjeto;
    }

    public void usarObjeto()
    {
        switch (objeto.TiposObjeto)
        {
            case Objetos.tipoObjeto.energia:
                estadisticasJugador.Instance.agregarSalud(objeto.valor);
                break;

            case Objetos.tipoObjeto.arma1:
                estadisticasJugador.Instance.activarEspadaHielo();
                break;

            case Objetos.tipoObjeto.arma2:
                estadisticasJugador.Instance.activarMandobleElectrico();
                break;

        }

        removerObjeto();
    }
}
