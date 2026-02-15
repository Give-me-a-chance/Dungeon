    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public float life = 6;
    [SerializeField]
    private Rigidbody bullet;
    [SerializeField]
    public float damage = 10;
    
    private void Awake()
    {
        Destroy(gameObject, life);
        Debug.Log("Пуля уничтожилась");
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        //Destroy(collision.gameObject);
        {
            Debug.Log(collision.gameObject.name);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("bullet")) return;

        if (other.CompareTag("Enemy"))
        {
            Simpleenemy enemy = other.GetComponent<Simpleenemy>();
            enemy?.TakeDamage(damage);
            Destroy(gameObject);
            return; // Выходим, чтобы не удалять дважды
        }

        // Удаляем пулю, только если она врезалась в стену/пол (не игрока)
        Destroy(gameObject);



    }

}
