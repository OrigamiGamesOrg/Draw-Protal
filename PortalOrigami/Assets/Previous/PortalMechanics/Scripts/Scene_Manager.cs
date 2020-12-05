using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }   
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void HomeScene()
    {
        SceneManager.LoadScene("Level Selection");
    }
    public void LevelsScene()
    {
        SceneManager.LoadScene("Level Selection");
    }
    public void PauseGame()
    {
        GameManager.instance.TogglePause();
    }
}
