using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverManager : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene(1); // เปลี่ยนไปที่ scene เกม
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0); // เปลี่ยนไปที่ scene เมนู
    }
}
