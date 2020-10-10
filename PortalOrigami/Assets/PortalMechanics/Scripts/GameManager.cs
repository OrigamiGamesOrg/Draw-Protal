using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private Scene_Manager scene;
    private Ui_Manager ui;

    public bool isPlaying = true;

    private void Awake() {
        instance = this;
        scene = GetComponent<Scene_Manager>();
        ui = GetComponent<Ui_Manager>();
    }
    public void TogglePause()
    {
        isPlaying = !isPlaying;
        ui.PausePanel();
    }
    public void GetCaught()
    {
        isPlaying = false;
        ui.GameOverPanel();
    }
    public void LevelComplete()
    {
        Invoke("NextLevel",0.5f);
    }
    public void NextRoom()
    {
        Camera.main.GetComponent<MoveToLevel>().MoveToNextPos();
    }

    private void NextLevel()
    {
        scene.NextScene();
    }
    private void RestartLevel()
    {
        scene.RestartScene();
    }

    public void DoorRoom()
    {
        PathCreator pc = FindObjectOfType<PathCreator>();
        pc.enabled = false;

        MouseManager mm = FindObjectOfType<MouseManager>();
        mm.enableThis = true;
    }
}
