using UnityEngine;

public class PlayerController : Character
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;

    public GameObject bombPrefab;
    public Transform throwPoint; // จุดที่ปล่อยระเบิด
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;

    /*public override void Start()
    {
        base.Start();
    }*/
   
    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
            animator.SetTrigger("Jump");
        }

        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }

        if (IsGrounded() && animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            animator.ResetTrigger("Jump");
            animator.Play("Idle");
        }

        // Attack
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
            ThrowBomb();
        }

        Flip();
    }
    public void ThrowBomb()   // ← สำคัญ ต้อง public ถึงจะให้อนิเมชันเรียกได้
    {
        GameObject bomb = Instantiate(bombPrefab, throwPoint.position, Quaternion.identity);

        // หาทิศทางตามการหันหน้า
        float dir = transform.localScale.x > 0 ? 1 : -1;
        bomb.GetComponent<Bomb>().Launch(new Vector2(dir, 0));
    }


    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
