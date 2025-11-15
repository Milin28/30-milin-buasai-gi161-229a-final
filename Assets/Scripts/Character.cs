using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP;

    public virtual void Start()
    {
        currentHP = maxHP;
    }

    public virtual void TakeDamage(int amount)
    {
        currentHP -= amount;
        if (currentHP <= 0)
        {
            Die();
        }
    }
    
    public virtual void Die()
    {
        Destroy(gameObject);
    }

}
