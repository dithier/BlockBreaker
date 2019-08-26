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
        int totalScenes = SceneManager.sceneCountInBuildSettings;
        int nextScene = (currentSceneIndex + 1) % totalScenes;
        // if loading the start scene, destroy to the gamestatus to restart score count
        if (nextScene == 0)
        {
            FindObjectOfType<GameStatus>().ResetGame();
        }
        SceneManager.LoadScene(nextScene);
    }

    public void LoadNextScene(float delay)
    {
        Invoke("LoadNextScene", delay);
    }

    public void QuitScene()
    {
        Application.Quit();
    }

}
