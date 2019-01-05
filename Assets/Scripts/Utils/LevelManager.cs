using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public void loadLevel(string level) {
        Debug.Log("LEVEL" + level);
        SceneManager.LoadScene(level);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
