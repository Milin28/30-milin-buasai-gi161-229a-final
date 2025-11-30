using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; }

    private int coins;
    public int Coins => coins;   // Encapsulation: อนุญาตให้อ่านได้อย่างเดียว

    [SerializeField] private TMP_Text coinsDisplay;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        UpdateCoinUI();
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        UpdateCoinUI();
    }

    private void UpdateCoinUI()
    {
        if (coinsDisplay != null)
        {
            coinsDisplay.text = coins.ToString();
        }
    }
}
