using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui_Manager : MonoBehaviour
{
    public GameObject InGame,Pause,GameOver;

    public void PausePanel()
    {
        InGame.SetActive(!InGame.activeSelf);
        Pause.SetActive(!Pause.activeSelf);
        GameOver.SetActive(false);
    }
    public void GameOverPanel()
    {
        InGame.SetActive(false);
        Pause.SetActive(false);
        GameOver.SetActive(true);
    }
}
