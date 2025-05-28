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

            for (int i = 0; i < ItemPremio.Length; i++)
            {
                ItemPremio[i].SetActive(true);
                Debug.Log($"La I vale {i}");

                if (ParticulaPremio.Length < i)
                {
                    Instantiate(ParticulaPremio[i], ItemPremio[i].transform.position, Quaternion.identity);
                    Debug.Log($"Se metió aquí en {i}, las particulas tienen valor de {ParticulaPremio.Length}");
                }
            }
            EnemigosTotales -= 1;
            gameObject.SetActive(false);
        }
    }
}
