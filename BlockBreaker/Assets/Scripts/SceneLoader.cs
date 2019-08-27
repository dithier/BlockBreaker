using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// because we are doing scene loading need to add proper namespace
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadNextScene(float delay)
    {
        Invoke("LoadNextScene", delay);
    }

    public void LoadStartMenu()
    {
        FindObjectOfType<GameStatus>().ResetGame();
        SceneManager.LoadScene(0);
    }

    public void QuitScene()
    {
        Application.Quit();
    }

}
