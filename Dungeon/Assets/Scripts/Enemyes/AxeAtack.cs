using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeAtack : MonoBehaviour
{
    public float damage = 5;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth Player = other.gameObject.GetComponent<PlayerHealth>();
        if (other.gameObject.CompareTag("Enemy"))
        {
            return;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            
            Player.TakeDamage(damage);
        }

    }
}
