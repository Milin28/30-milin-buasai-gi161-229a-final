using UnityEngine;

public class Mushroom : Enemy
{
    public Animator animator;

    public override void Start()
    {
        
        base.Start();
    }

    public override void TakeDamage(int amount)
    {
        base.TakeDamage(amount);
        animator.SetTrigger("Hurt");
    }

    public override void Die()
    {
        animator.SetTrigger("Die");
        Destroy(gameObject, 0.5f);
    }
}
