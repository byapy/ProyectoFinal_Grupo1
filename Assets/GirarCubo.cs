using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirarCubo : MonoBehaviour
{
    public GameObject cubito;
    public GameObject Capsula;

    public void Cubo()
    {
        cubito.SetActive(true);
        Capsula.SetActive(false);
        cubito.transform.Rotate(0, 100, 0);
    }
    public void GirarCapsula()
    {
        cubito.SetActive(false);
        Capsula.SetActive(true);
        Capsula.transform.Rotate(100, 0, 0);

    }
}
