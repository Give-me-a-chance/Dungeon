using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turel : MonoBehaviour
{

    public GameObject turel;
    Transform player;
    public float fireRate = 2;
    private float lastTimeFired;
    public GameObject bulletPrefab;
    public float bulletSpeed = 20;
    public Transform bulletSpawnPoint;
    public GameObject stand;



    // Update is called once per frame
    void Update()
    {
        if (turel != null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            float distance = Vector3.Distance(turel.transform.position, player.position);
            if (distance < 15)
            {
                turel.transform.LookAt(player);
                if (Time.time - lastTimeFired > 1 / fireRate)
                {
                    lastTimeFired = Time.time;
                    Vector3 playerpos = (bulletSpawnPoint.position - player.transform.position).normalized;
                    var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.LookRotation(-playerpos));
                    bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

                }

            }
        }
        else
            Destroy(stand);
        
    }
}
