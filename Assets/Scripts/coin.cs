using UnityEngine;

public class coin : MonoBehaviour
{
    [SerializeField] private int value;
    [SerializeField] private AudioClip collectSound; //sound
    private bool hasTriggered;
    private CoinManager coinManager;
    private AudioSource audioSource;
    private void Start()
    {
        coinManager = CoinManager.Instance;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.CompareTag("Player") && !hasTriggered)
       {
           hasTriggered = true;
           coinManager.changeCoins(value);
            if (audioSource != null && collectSound != null)
            {
                Debug.Log("Playing sound..."); // ตรวจสอบการเล่นเสียง
                audioSource.PlayOneShot(collectSound);
            }
            else
            {
                Debug.LogError("AudioSource or AudioClip is missing!"); // ถ้าไม่มี AudioSource หรือ AudioClip
            }

            Destroy(gameObject);
           
           
       }
    }
}
