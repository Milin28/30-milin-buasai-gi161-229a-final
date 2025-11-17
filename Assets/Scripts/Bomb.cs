using UnityEngine;

public class Bomb : MonoBehaviour
{
    public int damage = 5;        // ระเบิดทำดาเมจเท่าไหร่
    public float speed = 5f;       // ความเร็วที่ลอยไป
    public float lifeTime = 3f;    // ระยะเวลาก่อนทำลายตัวเอง

    private Vector2 direction;

    // ให้ player เรียกใช้เมื่อโยน
    public void Launch(Vector2 dir)
    {
        direction = dir.normalized;
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ถ้าเจอ Enemy
        Enemy enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
        {
            Debug.Log("Hit enemy, damage applied!");
            enemy.TakeDamage(damage); // ทำดาเมจ
            Destroy(gameObject);      // ลบระเบิดทันที
        }

    }
}
