using UnityEngine;

public class coin : MonoBehaviour
{
    [SerializeField] private int value = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CoinManager.Instance.changeCoins(value);   // เพิ่มจำนวนเหรียญ
            SFXManager.Instance.PlayCoin();            // เล่นเสียงเก็บเหรียญ
            Destroy(gameObject);                       // ลบเหรียญ
        }
    }
}
