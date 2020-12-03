using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ui_Manager : MonoBehaviour
{
    public GameObject InGame, Pause, GameOver;
    private Slider keybar;
    private int keypresent;

    private void Start()
    {
        keypresent = GameObject.FindGameObjectsWithTag("Key").Length;
        keybar = FindObjectOfType<Slider>();
        keybar.maxValue = keypresent;
    }

    private void Update()
    {
        int numberofkeyleft = GameObject.FindGameObjectsWithTag("Key").Length;
        int amount = keypresent - numberofkeyleft;
        keybar.value = amount;
    }
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