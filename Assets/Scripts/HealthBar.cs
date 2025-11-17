using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Header("Health Bar UI")]
    [SerializeField] private Slider slider;
    [SerializeField] private Vector3 worldOffset = new Vector3(0, 1.2f, 0); // ตำแหน่งเหนือหัว

    private Character target; // ตัวละครที่ HealthBar นี้ดูแล

    //  ฟังก์ชันให้ Manager หรือ Character เรียกใช้
    public void SetTarget(Character character)
    {
        if (target != null)
        {
            target.OnHealthChanged -= OnHealthChanged;
        }

        target = character;

        if (target != null)
        {
            target.OnHealthChanged += OnHealthChanged;
            UpdateSlider(target.Health, target.MaxHealth);
        }
    }

    // เมื่อค่า HP เปลี่ยน
    private void OnHealthChanged(int current)
    {
        UpdateSlider(current, target.MaxHealth);
    }

    private void UpdateSlider(int current, int max)
    {
        if (slider != null && max > 0)
            slider.value = (float)current / max;
    }

    // ให้แถบตามตำแหน่งตัวละคร
    private void LateUpdate()
    {
        if (target == null) return;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(target.transform.position + worldOffset);
        transform.position = screenPos;
    }

    private void OnDestroy()
    {
        if (target != null)
            target.OnHealthChanged -= OnHealthChanged;
    }
}