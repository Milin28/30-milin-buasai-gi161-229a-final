using UnityEditor.Overlays;
using UnityEngine;

public abstract class Enemy : Character
{
    [SerializeField] protected float moveSpeed = 5f;
    protected bool movingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    public Transform leftPoint;
    public Transform rightPoint;

    public override void Start()
    {
        base.Start();  // เรียกฟังก์ชัน Start() ของ Character class
        rb = GetComponent<Rigidbody2D>();  // กำหนดค่าให้กับ Rigidbody2D ของ Enemy
        rb.freezeRotation = true;  // ล็อคการหมุน
    }

    private void Update()
    {
        Move();

        // ถ้าไม่แตะพื้น = ดิ่งลง → Debug เตือน
        if (!IsGrounded())
        {
            Debug.Log("Enemy not grounded!");
        }
    }

    private bool IsGrounded()
    {
        // ตรวจพื้นด้วยวงกลมเล็ก ๆ ใต้เท้า
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }

    private void Move()
    {
        rb.MovePosition(new Vector2(
        transform.position.x + moveSpeed * Time.deltaTime,
        transform.position.y
    ));

    if (movingRight && transform.position.x > rightPoint.position.x)
        Flip();
    else if (!movingRight && transform.position.x < leftPoint.position.x)
        Flip();
    }

    private void Flip()
    {
        movingRight = !movingRight;

        // พลิก sprite
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        // กลับทิศ
        moveSpeed *= -1;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, 0.1f);
    }
}
