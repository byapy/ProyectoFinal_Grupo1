using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGauntlet : MonoBehaviour
{
    [SerializeField] GameObject[] ItemPremio, ParticulaPremio;
    [SerializeField] int EnemigosTotales;

    private void Start()
    {
        for (int i = 0; i < ItemPremio.Length; i++)
        {
            ItemPremio[i].SetActive(false);
        }

    }
    // Update is called once per frame
    void Update()
    {

        EnemigosTotales = transform.childCount;

        if (EnemigosTotales == 0)
        {
            DarPremio();
        }
    }

    void DarPremio()
    {
        for (int i = 0; i < ItemPremio.Length; i++)
        {
            ItemPremio[i].SetActive(true);

            if (i < ParticulaPremio.Length)
            {
                Instantiate(ParticulaPremio[i], ItemPremio[i].transform.position, ItemPremio[i].transform.rotation);
            }
        }
        //EnemigosTotales -= 1;
        Destroy(gameObject);
    }
}
