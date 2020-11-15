using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{
    string levelname;

    private void Start() {
        string btnName = gameObject.name;
        levelname = btnName.Replace("(", string.Empty).Replace(")",string.Empty).Replace(" ",string.Empty);
        transform.GetChild(0).GetComponent<Text>().text = levelname;
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene(levelname);
    }
}
