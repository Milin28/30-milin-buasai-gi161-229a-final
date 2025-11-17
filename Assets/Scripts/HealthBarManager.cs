
using System.Runtime.InteropServices;
using UnityEngine;

public class HealthBarManager : MonoBehaviour
{
    [SerializeField] private HealthBar healthBarPrefab; // ใส่ prefab ที่สร้างไว้
    private HealthBar inst;

    void Start()
    {
        Character character = GetComponent<Character>();
        if (character == null || healthBarPrefab == null) return;

        // สร้าง instance เป็น child ของ Canvas (หา Canvas ครั้งเดียว)
        Canvas canvas = FindObjectOfType<Canvas>();
        inst = Instantiate(healthBarPrefab, canvas.transform);
        inst.SetTarget(character);
    }

    private void OnDestroy()
    {
        if (inst != null)
            Destroy(inst.gameObject);
    }

}
