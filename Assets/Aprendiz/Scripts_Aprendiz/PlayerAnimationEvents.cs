using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAnimationEvents : MonoBehaviour
{

    public GameObject PantallaGameOver, PantallaGameplay;


    public void PlayerDies()
    {
        PantallaGameOver.SetActive(true);
        PantallaGameplay.SetActive(false);
        Time.timeScale = 0;
    }



}
