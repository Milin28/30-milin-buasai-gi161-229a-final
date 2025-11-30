using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Character
{
    private void Start()
    {
        Intialize(100);
    }

    public void OnHitWith(Enemy enemy)
    {
        TakeDamage(enemy.DamageHit);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            OnHitWith(enemy);
        }
    }

    protected override void OnDeath()
    {
        base.OnDeath();
        SceneManager.LoadScene(2);
    }
}