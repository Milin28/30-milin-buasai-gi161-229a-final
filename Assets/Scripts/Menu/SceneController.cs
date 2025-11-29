using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    // ทำเป็น Singleton ให้เรียกใช้จากที่ไหนก็ได้
    public static SceneController Instance { get; private set; }
    // --------- เมธอดที่ UI หรือสคริปต์อื่นเรียกใช้ ---------

    //menu
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    //gameover
    public void PlayAgain()
    {
        SceneManager.LoadScene(1); // เปลี่ยนไปที่ scene เกม
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    
    //gamewin
    public void Win()
    {
        SceneManager.LoadScene(3);
    }

    
}
