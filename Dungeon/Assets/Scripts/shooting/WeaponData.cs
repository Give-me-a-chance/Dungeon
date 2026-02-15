using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponData : MonoBehaviour
{
    public WeaponType type;
    public List<Transform> spawnPoints;
    public GameObject bulletPrefab;
    public float fireRate;
    public float scatter;
}
