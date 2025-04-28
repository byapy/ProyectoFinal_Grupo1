using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int nivelProgreso = 1;
   
    public void AumentarProgreso()
    {
        nivelProgreso++;
        Debug.Log($"Progreso actualizado Nivel actual {nivelProgreso}");
    }
}
