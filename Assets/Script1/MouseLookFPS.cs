using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookFPS : MonoBehaviour
{
    public float sensibilidad;
    public GameObject player;
    float XRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Aprendiz");
    }

    // Update is called once per frame
    void Update()
    {
        float mousex = Input.GetAxis("Mouse X") * sensibilidad * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidad * Time.deltaTime;

        XRotation -= mouseY;
        XRotation = Mathf.Clamp(XRotation, -90f, 90f);  //esta linea de código agrega un tope en el giro, para girar 90 grados*/

        transform.localRotation = Quaternion.Euler(0, 0, 0);
        player.transform.Rotate(Vector3.up*mousex);
    }
}
