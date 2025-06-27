using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UbicacionNPCMapa : MonoBehaviour
{
    [SerializeField] Sprite IconoNPC;
    [SerializeField] Image PrefabImagen;
    [SerializeField] Transform NivelEnElMapa;
    [SerializeField] Transform NivelEnElMapaGrande;


    Image InstanciaIcono, InstanciaIconoGrande;

    // Start is called before the first frame update
    void Start()
    {
        InstanciaIcono = Instantiate(PrefabImagen, NivelEnElMapa.transform);
        InstanciaIconoGrande = Instantiate(PrefabImagen, NivelEnElMapaGrande.transform);

        InstanciaIcono.sprite = IconoNPC;
        InstanciaIconoGrande.sprite = IconoNPC;

        InstanciaIcono.transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
        //    FlechaMapaGrande.localPosition = new Vector3(FlechaMinimapa.localPosition.x, FlechaMinimapa.localPosition.y);
        InstanciaIconoGrande.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        InstanciaIconoGrande.transform.localPosition = new Vector3(InstanciaIcono.transform.localPosition.x, InstanciaIcono.transform.localPosition.y);
    }

    // Update is called once per frame
    void Update()
    {
        InstanciaIcono.transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
        InstanciaIconoGrande.transform.localPosition = new Vector3(InstanciaIcono.transform.localPosition.x, InstanciaIcono.transform.localPosition.y);

    }

    private void OnDestroy()
    {
        Destroy(InstanciaIcono);
        Destroy(InstanciaIconoGrande);

    }
}
