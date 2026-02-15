using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereDamage : MonoBehaviour
{
    public int Damage = 10;
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
            enemy.TakeDamage(Damage);
            
            
        }


    }
}
