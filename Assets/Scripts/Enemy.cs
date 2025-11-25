using UnityEditor.Overlays;
using UnityEngine;

public abstract class Enemy : Character
{
    public int DamageHit { get; protected set; }
    public abstract void Behavior();
    public Transform headPoint;
    public HealthBar healthBarPrefab;

    private HealthBar hb;

    protected virtual void Start()
    {
        // สร้าง HealthBar บน Canvas
        if (healthBarPrefab != null)
        {
            Canvas canvas = FindObjectOfType<Canvas>();
            hb = Instantiate(healthBarPrefab, canvas.transform);
            hb.SetTarget(this, headPoint);
        }
    }
    public void Die()
    {
        // เรียกอนิเมชัน FadeOut
        //animator.SetTrigger("Die"); // สมมติว่า "Die" คือ trigger ที่เรียกอนิเมชัน FadeOut

        // รอให้อนิเมชัน FadeOut เล่นจนจบ (เวลาอนิเมชันนี้เป็นเวลาเท่าไหร่)
        Destroy(gameObject); // ทำลายตัว Mushroom หลังจากอนิเมชันเล่นเสร็จ (1 วินาที)
    }
}
