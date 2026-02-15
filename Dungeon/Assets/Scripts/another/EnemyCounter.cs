using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{
    public static int Killed { get; set; }
    public static int Enemycount { get; set; }
    public static float Timer { get; set; }


    void OnEnable()
    {
        Simpleenemy.OnEnemyKilled += UpdateUI;
        Simpleenemy.OnEnemySpawned += RegisterEnemy; 
    }

    void OnDisable()
    {
        Simpleenemy.OnEnemyKilled -= UpdateUI;
        Simpleenemy.OnEnemySpawned -= RegisterEnemy;
    }

    void RegisterEnemy()
    {
        Enemycount++; // Увеличиваем счетчик при спавне каждого врага
        UpdateText();
    }

    void Start()
    {
        ResetStats();
        UpdateText();
    }

    private void Update()
    {
        Timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ResetStats();
            SceneManager.LoadScene(0);
        }
    }

    void UpdateUI(Simpleenemy enemy)
    {
        Killed++;
        Enemycount--;
        UpdateText();

        // ПРОВЕРКА ПОБЕДЫ: только когда кто-то умер
        if (Enemycount <= 0 && Killed > 0)
        {
            GoldsCounter.Time = Timer;
            GoldsCounter.Kills = Killed;

            ResetStats();
            SceneManager.LoadScene(3);
        }
    }

    void UpdateText()
    {
        GetComponent<TextMeshProUGUI>().text = "Врагов осталось: " + Enemycount;
    }

    void ResetStats()
    {
        Killed = 0;
        Enemycount = 0;
        Timer = 0;
    }
}


