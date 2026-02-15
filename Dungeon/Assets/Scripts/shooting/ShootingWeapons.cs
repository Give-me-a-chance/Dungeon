using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum WeaponType { Pistol, Shotgun, Automatic }
public class ShootingWeapons : MonoBehaviour
{
    public WeaponData currentWeaponData; // Сюда будем подставлять активную пушку
    public Camera fpsCam;
    public LayerMask aimColliderMask;
    public float bulletSpeed = 60f;

    private CameraRotation cameraRotation;
    private float lastTimeFired;
    private bool isShooting = false;

    private void Start()
    {
        cameraRotation = fpsCam.GetComponent<CameraRotation>();
    }

    // Этот метод теперь ОДИН на всё про всё!
    public void OnFire(InputValue value)
    {
        if (currentWeaponData == null) return;
        Debug.Log("Shoot");
        if (value.isPressed)
        {
            if (currentWeaponData.type == WeaponType.Automatic)
            {
                isShooting = true;
            }
            else
            {
                TryShoot();
            }
        }
        else
        {
            isShooting = false;
        }
    }

    private void Update()
    {
        if (isShooting && currentWeaponData != null && currentWeaponData.type == WeaponType.Automatic)
        {
            Debug.Log("Ну нажал же я");
            TryShoot();
        }
    }

    private void TryShoot()
    {
        // Берем настройки из текущей пушки
        if (Time.time - lastTimeFired < 1f / currentWeaponData.fireRate) return;
        lastTimeFired = Time.time;

        Vector3 target = GetTargetPoint();

        if (currentWeaponData.type == WeaponType.Shotgun)
            SpawnBullets(target, currentWeaponData.spawnPoints.Count);
        else
            SpawnBullets(target, 1);

        cameraRotation?.Recoil();
    }

    private void SpawnBullets(Vector3 target, int count)
    {
        for (int i = 0; i < count; i++)
        {
            // Берем точки спавна из данных текущей пушки
            Transform spawn = currentWeaponData.spawnPoints[i % currentWeaponData.spawnPoints.Count];
            Vector3 baseDir = (target - spawn.position).normalized;

            // Применяем разброс из данных текущей пушки
            Vector3 finalDir = ApplySpread(baseDir, currentWeaponData.scatter);

            GameObject bullet = Instantiate(currentWeaponData.bulletPrefab, spawn.position, Quaternion.LookRotation(finalDir));
            bullet.GetComponent<Rigidbody>().velocity = finalDir * bulletSpeed;
        }
    }

    private Vector3 ApplySpread(Vector3 direction, float weaponScatter)
    {
        if (weaponScatter <= 0) return direction;
        return Quaternion.Euler(Random.Range(-weaponScatter, weaponScatter), Random.Range(-weaponScatter, weaponScatter), 0) * direction;
    }
    private Vector3 GetTargetPoint()
    {
        Ray ray = fpsCam.ScreenPointToRay(new Vector2(Screen.width / 2f, Screen.height / 2f));
        if (Physics.Raycast(ray, out RaycastHit hit, 999f, aimColliderMask))
        {
            return hit.point;
        }
        return ray.origin + ray.direction * 100f;
    }
}
