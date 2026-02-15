using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float fireRate = 1;
    private float lastTimeFired;

    // Update is called once per frame
    void Update()
    {
        Shooting();
    }
    public void Shooting()
    {
        if (Time.time - lastTimeFired > 1 / fireRate)
        {
            lastTimeFired = Time.time;
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.LookRotation(Vector3.right));
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
            
        }
    }
}
