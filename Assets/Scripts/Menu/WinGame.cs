using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPoint : MonoBehaviour
{
    [SerializeField] private int sceneIndex = 3;
    [SerializeField] private int requiredCoins = 50;
    //public int sceneIndex = 3; // เลขตาม Build Settings

    [Header("UIGem")]
    [SerializeField] private TMP_Text warningText;
    [SerializeField] private float warningDuration = 1f; // แสดง 2 วินาที
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        if (CoinManager.Instance.Coins >= requiredCoins)
        {
            SceneManager.LoadScene(sceneIndex);
        }
        else
        {
            ShowWarning();
        }
        
    }
    private void ShowWarning()
    {
        if (warningText != null)
        {
            warningText.gameObject.SetActive(true);
            warningText.text = $"!!Need { requiredCoins} Gem!!";
            CancelInvoke(nameof(HideWarning));
            Invoke(nameof(HideWarning), warningDuration);
        }
    }

    private void HideWarning()
    {
        if (warningText != null)
        {
            warningText.gameObject.SetActive(false);
        }
    }
}