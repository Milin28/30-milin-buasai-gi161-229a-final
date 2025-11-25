using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;
    private int coins;
    [SerializeField] private TMP_Text coinsDisplay;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
        }
      
    }
    private void OnGUI()
    {
        coinsDisplay.text = coins.ToString();
    }
    public void changeCoins(int amount)
    {
        coins += amount;
    }
}
