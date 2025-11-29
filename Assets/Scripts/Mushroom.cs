using UnityEngine;

public class Mushroom : Enemy
{
    [SerializeField] public Vector2 velocity;
    public Transform[] MovePoint;
    public Vector3 offset;
    public float attackRange = 1.5f; // ระยะโจมตี
    public float attackCooldown = 1.0f; // เวลาระหว่างการโจมตี
    private float lastAttackTime = 0f;  // เวลาครั้งล่าสุดที่โจมตี
    private Animator animator; // เพิ่ม Animator
    private bool isAttacking = false; // สถานะการโจมตี
    void Start()
    {
        base.Intialize(20);
        DamageHit = 20;
        // Get the Animator component
        animator = GetComponent<Animator>();

        if (MovePoint.Length >= 2)
        {
            // บังคับให้เห็ดเริ่มเดินไปหา point ที่ใกล้ที่สุด
            if (transform.position.x > MovePoint[1].position.x)
                velocity = new Vector2(-1f, 0);   // ถ้าอยู่ขวา → เดินซ้าย
            else
                velocity = new Vector2(1f, 0);    // ถ้าอยู่ซ้าย → เดินขวา
        }
    }
    public override void Behavior()
    {
        //move from current position
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

        //move left
        if (velocity.x < 0 && rb.position.x <= MovePoint[0].position.x)
        {
            Flip();
        }
        //move right 
        if (velocity.x > 0 && rb.position.x >= MovePoint[1].position.x)
        {
            Flip();
        }
        // ตรวจสอบระยะห่างจาก Player และโจมตีหากอยู่ในระยะ
        if (IsPlayerInRange())
        {
            Attack();
        }
        else if (!isAttacking) // ถ้าไม่ได้โจมตี ให้กลับไปเดิน
        {
            // Set walking animation
            if (animator != null)
            {
                animator.SetBool("isWalking", true); // Set to walking
            }
        }

    }
    public void Attack()
    {
        // ตรวจสอบเวลาระหว่างการโจมตี
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            lastAttackTime = Time.time;

            // หา Player และโจมตี
            Player player = FindObjectOfType<Player>(); // หา Player ใน scene
            if (player != null)
            {
                Debug.Log("Mushroom attacking the player!");
                // เล่นแอนิเมชันโจมตี
                if (animator != null)
                {
                    animator.SetTrigger("Attack"); // เรียก trigger "Attack" เพื่อเล่นท่าโจมตี
                    animator.SetBool("isWalking", false); // หยุดเดินระหว่างโจมตี
                }

                isAttacking = true;
                player.TakeDamage(DamageHit); // ลดพลังชีวิตของ Player
            }
        }
    }
    // ตรวจสอบว่าผู้เล่นอยู่ในระยะโจมตีหรือไม่
    private bool IsPlayerInRange()
    {
        Player player = FindObjectOfType<Player>(); // หา Player ใน scene
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
            return distanceToPlayer <= attackRange;
        }
        return false;
    }
    //flip ant to the opposite direction
    public void Flip()
    {
        velocity.x *= -1; //change direction of movement
                          //Flip the image
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void FixedUpdate()
    {
        Behavior();
    }


}