using Assets.Scripts;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Simpleenemy : MonoBehaviour
{
    
    public float health;
    public GameObject HealthBarCanvas;
    public HealthBar healthBar;
    public GameObject ExplosionPrefab;
    private bool isDead = false;
    public static event Action<Simpleenemy> OnEnemyKilled;
    public SpawnPoint mySpawn;
    public static event Action OnEnemySpawned; 

    void Awake()
    {
        OnEnemySpawned?.Invoke();
    }
    public void TakeDamage(float damage)
    {
        if (isDead)  
            return;

        healthBar = HealthBarCanvas.GetComponent<HealthBar>();
        health -= damage;
        healthBar.ChangeValue(damage);
        if (health <= 0)
        {
            isDead = true;
            Instantiate(ExplosionPrefab, transform.position, Quaternion.identity); 
            Destroy(gameObject);
            OnEnemyKilled?.Invoke(this);

           // GlobalEventManager.SetImprovePanel();
        }
    }

    public void Heal(float damage)
    {
        if (health < 100)
        {
            healthBar = HealthBarCanvas.GetComponent<HealthBar>();
            health += damage;
            healthBar.UpValue(damage);
        }
    }

    

    
}
