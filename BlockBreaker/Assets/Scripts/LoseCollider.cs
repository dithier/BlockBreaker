using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// because we are doing scene loading need to add proper namespace
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("GameOver");
    }
}
