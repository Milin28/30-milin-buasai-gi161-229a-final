using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;

    [Header("UI Sounds")]
    public AudioSource sfxSource;
    public AudioClip uiClick;
    public AudioClip coinPickup;

    private void Awake()
    {
        // ทำเป็น Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // อยู่ข้ามซีนได้
    }
    public void PlayCoin()
    {
        if (sfxSource != null && coinPickup != null)
        {
            sfxSource.PlayOneShot(coinPickup);
        }
    }


    public void PlayClick()
    {
        if (sfxSource != null && uiClick != null)
        {
            sfxSource.PlayOneShot(uiClick);
        }
    }
}
