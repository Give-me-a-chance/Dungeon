using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Goblin;
    Transform player;
    public float fireRate = 1;
    private float lastTimeFired;
    public Animation anim;
    

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        float distance = Vector3.Distance(Goblin.transform.position, player.position);
        if (distance < 8)
        {
            //anim.Play("walk-loop");
            Goblin.transform.LookAt(player);
            if (Time.time - lastTimeFired > 1 / fireRate)
            {
                
            }

        }
    }
}
