using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPoint : MonoBehaviour
{
    public int sceneIndex = 3; // เลขตาม Build Settings

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(3);
        }
    }
}