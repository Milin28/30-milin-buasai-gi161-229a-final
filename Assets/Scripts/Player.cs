using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : Character
{
    [field: SerializeField] public GameObject Bullet { get; set; }
    [field: SerializeField] public Transform ShootPoint { get; set; }
    [field: SerializeField] public float ReloadTime { get; set; }
    [field: SerializeField] public float WaitTime { get; set; }
    public AudioSource audioSource;
    public AudioClip coinSound;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Intialize(100);
        ReloadTime = 1.0f;
        WaitTime = 0.0f;
        audioSource = GetComponent<AudioSource>();
    }
    public void OnHitWith(Enemy enemy)
    {
        TakeDamage(enemy.DamageHit);
        //IsDead();
    }
    private void FixedUpdate()
    {
        WaitTime += Time.fixedDeltaTime;
        //Debug.Log("time :" + Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other )
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            Debug.Log($"{this.name} Hit with {enemy.name}!");
            OnHitWith(enemy);
            
        }

    }
    protected override void OnDeath()
    {
        base.OnDeath(); // ลบ GameObject ทันที
        GameOver();
    }
    private void GameOver()
    {
        SceneManager.LoadScene(2);
    }

    // Update is called once per frame
    private void Update()
    {
       /* if (IsDead())
        {
            GameOver(); // เรียกฟังก์ชัน GameOver
        }*/
    }

   
}
