using System;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public event Action<int> OnHealthChanged; // event HealthBar

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

    //method
    public void Intialize(int startHealth)
    {
        maxHealth = startHealth;
        Health = startHealth;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Debug.Log($"{this.name} initialized with Health: {Health}");
        /*Health = starHealth;
        Debug.Log($"{this.name} initial Health: {Health}");
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();*/
    }

    // method
    public void TakeDamage(int damage)
    {

        Health -= damage;
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        Debug.Log($"{this.name} took damage {damage}. Current Health: {Health}");
        OnHealthChanged?.Invoke(Health);
        IsDead();
    }

    public bool IsDead()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log($"{this.name} is dead. and destroyed!");
            return true;
        }
        else
            return false;
    }


    void Start()
    {

    }


}