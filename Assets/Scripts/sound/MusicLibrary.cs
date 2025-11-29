using UnityEngine;

public class MusicLibrary : MonoBehaviour
{
    public static MusicLibrary Instance;

    private void Awake()
    {
        // ถ้ามี MusicManager อยู่แล้ว → ตัวใหม่ไม่ต้องอยู่
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);  // อยู่ข้ามซีนได้
    }
}
