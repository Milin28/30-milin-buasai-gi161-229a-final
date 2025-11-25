using UnityEngine;

public class Bomb : MonoBehaviour
{
    public int damage = 5;        
    public float speed = 5f;      
    public float lifeTime = 1f;    

    private Vector2 direction;

   
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
        
        Enemy enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
        {
            Debug.Log("Hit enemy, damage applied!");
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
