using UnityEngine;

public abstract class Enemy : Character
{
    public int DamageHit { get; protected set; }

    [Header("UI")]
    public Transform headPoint;
    public HealthBar healthBarPrefab;

    private HealthBar hb;

    protected virtual void Start()
    {
        // init health (ถ้าอยาก override ค่อยไปทำใน subclass)
        if (healthBarPrefab != null)
        {
            Canvas canvas = FindObjectOfType<Canvas>();
            hb = Instantiate(healthBarPrefab, canvas.transform);
            hb.SetTarget(this, headPoint);
        }
    }

    public abstract void Behavior();  // <-- polymorphism ตรงนี้

    protected override void OnDeath()
    {
        if (hb != null)
            Destroy(hb.gameObject);

        base.OnDeath();
    }

    private void FixedUpdate()
    {
        Behavior();     // ทุก enemy จะเรียก Behavior ของตัวเอง
    }
}