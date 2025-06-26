using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UbicacionNPCMapa : MonoBehaviour
{
    [SerializeField] Sprite IconoNPC;
    [SerializeField] Image PrefabImagen;
    [SerializeField] Transform NivelEnElMapa;

    Image InstanciaIcono;

    // Start is called before the first frame update
    void Start()
    {
        InstanciaIcono = Instantiate(PrefabImagen, NivelEnElMapa.transform);
        InstanciaIcono.sprite = IconoNPC;
        InstanciaIcono.transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        InstanciaIcono.transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
    }

    private void OnDestroy()
    {
        Destroy(InstanciaIcono);
    }
}
