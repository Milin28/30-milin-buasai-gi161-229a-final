using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    private Character player;

    private void Start()
    {
        player = FindAnyObjectByType<Player>();   // หรือ FindObjectOfType<Player>();
        if (player != null)
        {
            player.OnHealthChanged += OnHealthChanged;
            slider.value = (float)player.Health / player.MaxHealth;
        }
    }

    private void OnHealthChanged(int current)
    {
        slider.value = (float)current / player.MaxHealth;
    }

    private void OnDestroy()
    {
        if (player != null)
            player.OnHealthChanged -= OnHealthChanged;
    }
}
