using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolUltBullet : MonoBehaviour
{
    [SerializeField]
    public float life = 3;
    [SerializeField]
    private Rigidbody bullet;
    [SerializeField]
    public float damage = 50;

    private void Awake()
    {
        Destroy(gameObject, life);
        Debug.Log("Пуля уничтожилась");
    }


    private void OnTriggerEnter(Collider other)
    {
        Simpleenemy enemy = other.gameObject.GetComponent<Simpleenemy>();
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("MainCamera") || other.gameObject.CompareTag("bullet"))
        {
            return;
        }
        if (other.gameObject.tag == "Enemy")
        {
            enemy.TakeDamage(damage);
            damage += 10;
        }


    }
}
