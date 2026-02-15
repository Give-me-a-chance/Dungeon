using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SgUltBullet : MonoBehaviour
{
    public float Damage;
    public GameObject ExpPrefab;
    
  
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
            enemy.TakeDamage(Damage * 5);
            Instantiate(ExpPrefab, transform.position, Quaternion.identity);          
            Destroy(gameObject);
        }

        Instantiate(ExpPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
