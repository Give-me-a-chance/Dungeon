using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidHealing : MonoBehaviour
{
    protected int HealValue;
    // Start is called before the first frame update
    void Start()
    {
        HealValue = Random.Range(10,30);
    }

    // Update is called once per frame
    public void OnTriggerEnter(Collider other)
    {
        PlayerHealth player = other.gameObject.GetComponent<PlayerHealth>();
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            if (player.health < 100)
            {
                player.Heal(HealValue);
                Destroy(gameObject);
            }
        }
    }
}
