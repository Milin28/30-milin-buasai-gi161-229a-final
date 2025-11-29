using Unity.VisualScripting;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public int damage = 5;        
    public float speed = 5f;      
    public float lifeTime = 1f;
    public AudioClip explosionSound;   // เสียงระเบิด

    private Vector2 direction;
    private bool hasExploded = false;  // กันไม่ให้ระเบิดซ้ำ

    public void Launch(Vector2 dir)
    {
        direction = dir.normalized;
        // ตั้งเวลาให้มันระเบิด (แม้ไม่โดน)
        Invoke(nameof(Explode), lifeTime);
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Enemy enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Explode();
            
        }
    }
    void Explode()
    {
        if (hasExploded) return;   // กันไม่ให้ระเบิดซ้ำ
        hasExploded = true;

        // เล่นเสียงระเบิด
        if (explosionSound != null)
        {
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        }

        Destroy(gameObject);
    }
}
