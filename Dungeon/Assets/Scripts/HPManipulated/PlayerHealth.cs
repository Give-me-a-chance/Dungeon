using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100;
    public GameObject HealthBarCanvas;
    public PlayerHealthBar healthBar;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    public void TakeDamage(float damage)
    {
        healthBar = HealthBarCanvas.GetComponent<PlayerHealthBar>();
        health -= damage;
        healthBar.ChangeValue(damage);
        if (health <= 0)
        {
            Time.timeScale = 0f;
            
            GoldsCounter.Time = EnemyCounter.Timer;
            GoldsCounter.Kills = EnemyCounter.Killed;
            EnemyCounter.Killed = 0;
            EnemyCounter.Enemycount = 0;
            EnemyCounter.Timer = 0;
            SceneManager.LoadScene(3);
        }
    }
    public void Heal(int value)
    {
        if (health <= 100)
        {
            healthBar = HealthBarCanvas.GetComponent<PlayerHealthBar>();
            health += value;
            healthBar.UpValue(value);
            
        }
        
    }
}
