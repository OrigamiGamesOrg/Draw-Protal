using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ui_Manager : MonoBehaviour
{
    public GameObject InGame, Pause, GameOver;
    private Slider keybar;
    private int keypresent;
    public GameObject InfinteUI;
    public GameObject PortalDrawInfo;

    private void Start()
    {
        keypresent = GameObject.FindGameObjectsWithTag("Key").Length;
        keybar = FindObjectOfType<Slider>();
        keybar.maxValue = keypresent;
        PortalDrawInfo.SetActive(true);
        //InfinteUI.SetActive(true);
    }

    private void Update()
    {
        int numberofkeyleft = GameObject.FindGameObjectsWithTag("Key").Length;
        int amount = keypresent - numberofkeyleft;
        keybar.value = amount;
        if (Input.touchCount >= 1)
        {
            InfinteUI.SetActive(false);
            PortalDrawInfo.SetActive(false);
        }
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