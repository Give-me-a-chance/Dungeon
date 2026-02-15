using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[System.Serializable]
public class SpawnPoint
{
    public GameObject GameObject;
    public bool IsOccupied;
}

public class Respawn : MonoBehaviour
{
   public List<SpawnPoint> SpawnPoints;
   public GameObject EnemyPrefab;

    void Start()
    {
        // При запуске сцены заполняем все точки врагами
        foreach (var point in SpawnPoints)
        {
            SpawnAt(point);
        }
    }

    private void OnEnable()
    {
        Simpleenemy.OnEnemyKilled += HandleEnemyKilled;
    }

    private void OnDisable()
    {
        Simpleenemy.OnEnemyKilled -= HandleEnemyKilled;
    }

    private async void HandleEnemyKilled(Simpleenemy enemy)
    {
        if (enemy.mySpawn == null) return;

        var point = enemy.mySpawn;

        point.IsOccupied = false;

        await Task.Delay(2000);
        if (!this) return;

        SpawnAt(point);
    }

    private void SpawnAt(SpawnPoint point)
    {
        point.IsOccupied = true;

        var enemy = Instantiate(EnemyPrefab, point.GameObject.transform.position, Quaternion.identity);
        enemy.GetComponent<Simpleenemy>().mySpawn = point;
    }


}
