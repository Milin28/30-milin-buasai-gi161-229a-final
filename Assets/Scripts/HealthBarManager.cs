
using System.Runtime.InteropServices;
using UnityEngine;

public class HealthBarManager : MonoBehaviour
{
    [SerializeField] private HealthBar healthBarPrefab; 
    private HealthBar inst;
    [SerializeField] private Transform headPoint;
    void Start()
    {
        Character character = GetComponent<Character>();
        if (character == null || healthBarPrefab == null) return;

        
        Canvas canvas = FindObjectOfType<Canvas>();
        inst = Instantiate(healthBarPrefab, canvas.transform);
        inst.SetTarget(character, headPoint);
    }

    private void OnDestroy()
    {
        if (inst != null)
            Destroy(inst.gameObject);
    }

}
