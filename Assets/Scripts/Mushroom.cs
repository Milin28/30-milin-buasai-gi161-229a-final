using UnityEngine;

public class Mushroom : Enemy
{
    [Header("Movement")]
    [SerializeField] private Vector2 velocity;         // ใส่ค่า X ให้ไม่เป็น 0 ใน Inspector
    [SerializeField] private Transform[] movePoints;   // จุดซ้าย-ขวา

    [Header("Attack")]
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private float attackCooldown = 1.0f;

    private float lastAttackTime;
    private bool isAttacking;

    // ตัวแปรของเห็ดเอง (ไม่ไปพึ่ง Enemy)
    private Animator animator;
    private Player targetPlayer;
    private bool facingLeft = true;

    // ใช้ Awake ปกติ ไม่ override อะไร
    private void Awake()
    {
        animator = GetComponent<Animator>();

        // หา player ครั้งเดียวตอนเริ่ม
        // (warning obsolete เฉย ๆ แต่ยังใช้ได้ ถ้าอยากแก้ค่อยเปลี่ยนเป็น FindFirstObjectByType)
        targetPlayer = FindObjectOfType<Player>();

        // hp / damage ของเห็ด
        Intialize(20);   // ใช้ชื่อเดียวกับฟังก์ชันเดิมของเธอ
        DamageHit = 20;
    }

    // Enemy ควรมีเมธอด virtual/abstract ชื่อ Behavior อยู่แล้ว
    public override void Behavior()
    {
        if (!isAttacking)
        {
            Patrol();
        }

        HandleAttack();
    }

    private void Patrol()
    {
        if (isAttacking) return;

        // ให้เห็ดเดินตาม velocity
        rb.MovePosition(rb.position + velocity * Time.deltaTime);

        // เดินไปกลับระหว่าง 2 จุด
        if (movePoints.Length >= 2)
        {
            if ((velocity.x < 0 && rb.position.x <= movePoints[0].position.x) ||
                (velocity.x > 0 && rb.position.x >= movePoints[1].position.x))
            {
                Flip();
            }
        }

        if (animator != null)
            animator.SetBool("isWalking", true);
    }

    private void HandleAttack()
    {
        if (targetPlayer == null) return;

        float distance = Vector2.Distance(transform.position, targetPlayer.transform.position);

        // ถ้าไกลเกินระยะโจมตี → เลิกตี กลับไปเดิน
        if (distance > attackRange)
        {
            isAttacking = false;
            if (animator != null)
                animator.SetBool("isWalking", true);
            return;
        }

        // คูลดาวน์ยังไม่หมด
        if (Time.time - lastAttackTime < attackCooldown)
            return;

        lastAttackTime = Time.time;
        isAttacking = true;

        if (animator != null)
        {
            animator.SetTrigger("Attack");
            animator.SetBool("isWalking", false);
        }

        // ตีแบบง่าย ๆ ถ้าอยากให้ตรงเฟรมอนิเมชันจริง ๆ ค่อยย้ายไปใช้ Animation Event
        targetPlayer.TakeDamage(DamageHit);
    }

    private void Flip()
    {
        // กลับทิศการเดิน
        velocity.x *= -1;
        facingLeft = !facingLeft;

        // กลับสเกลให้หันคนละด้าน
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    // ไว้ใช้กับ Animation Event ถ้าต้องการ
    public void ApplyAttackDamage()
    {
        if (targetPlayer == null) return;

        float distance = Vector2.Distance(transform.position, targetPlayer.transform.position);
        if (distance <= attackRange)
        {
            targetPlayer.TakeDamage(DamageHit);
        }
    }
}
