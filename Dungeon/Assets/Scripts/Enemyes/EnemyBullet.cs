using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float life = 6;
    [SerializeField]
    private Rigidbody bullet;
    [SerializeField]
    public float damage = 10;
    public GameObject ExplosionPrefab;

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth Player = other.gameObject.GetComponent<PlayerHealth>();
        Simpleenemy enemy = other.gameObject.GetComponent<Simpleenemy>();
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("EnemyBullet") )
        {
            return;
        }
        if (other.gameObject.tag == "Player")
        {
            Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
            Player.TakeDamage(damage);
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
                enemy.Heal(damage);
                Destroy(gameObject);   
        }
       
        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
