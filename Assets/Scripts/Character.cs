using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Character : MonoBehaviour
{
    // event HealthBar
    public event Action<int> OnHealthChanged; 

    // attribute
    [SerializeField] private int maxHealth = 100;
    public int MaxHealth => maxHealth;

    private int health;
    public int Health
    {
        get => health;
        set
        {
            health = Mathf.Clamp(value, 0, maxHealth);
            OnHealthChanged?.Invoke(health);
        }
    }
    protected Animator anim;
    protected Rigidbody2D rb;
    protected virtual void CacheComponents()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    //method
    public void Intialize(int startHealth)
    {
        maxHealth = startHealth;
        Health = startHealth;
        CacheComponents();
        Debug.Log($"{this.name} initialized with Health: {Health}");
        
    }

    // method
    public void TakeDamage(int damage)
    {

        Health -= damage;
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        
        Debug.Log($"{this.name} took damage {damage}. Current Health: {Health}");
        if (IsDead())
        {
            Debug.Log($"{this.name} is dead!");
            OnDeath();
        }
        /*OnHealthChanged?.Invoke(Health);
        IsDead();*/
    }
    protected virtual void OnDeath()
    {
        Destroy(gameObject);
    }
    public bool IsDead()
    {
        return Health <= 0;
       
    }
    public bool TryGetEnemyFromCollision(Collider2D collision, out Enemy enemy)
    {
        enemy = collision.GetComponent<Enemy>();
        return enemy != null;
    }



}