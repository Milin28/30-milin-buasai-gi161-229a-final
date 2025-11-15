using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    [Header("Player HP Settings")]
    public int maxHealth = 100;
    public int currentHealth;

    [Header("UI")]
    public Slider healthBar;

    private Animator animator;
    private bool isDead = false;

    public override void Start()
    {
        base.Start();

        currentHealth = maxHealth;
        animator = GetComponent<Animator>();

        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }
    }

    public override void TakeDamage(int damage)
    {
        if (isDead) return;

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (healthBar != null)
            healthBar.value = currentHealth;

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public override void Die()
    {
        if (isDead) return;

        isDead = true;
        animator.SetTrigger("Die");

        GetComponent<PlayerController>().enabled = false;

        Debug.Log("Player Died!");
    }

    public void Heal(int amount)
    {
        if (isDead) return;

        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (healthBar != null)
            healthBar.value = currentHealth;
    }
}
