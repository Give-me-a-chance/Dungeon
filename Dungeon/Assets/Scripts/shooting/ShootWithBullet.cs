using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWithBullet : MonoBehaviour
{

    public List<Transform> bulletSpawnPoint;
    public PLayerMove playerMove;
    public Transform player;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public Camera fpsCam;
    // [SerializeField] private Transform debugTransform;
    [SerializeField] private LayerMask aimColliderMask;
    public float fireRate;
    private float lastTimeFired;
    public Transform aimCamera;
    private AudioSource AudioSource;
    public static float scatter;
    public GameObject UltPistolBullet;

    public CameraRotation cameraRotation;
    private void Start()
    {
        cameraRotation = fpsCam.GetComponent<CameraRotation>();
        AudioSource = GetComponent<AudioSource>();
        playerMove = player.GetComponent<PLayerMove>();
        cameraRotation = fpsCam.GetComponent<CameraRotation>();

        WeaponData[] weapons = GetComponentsInChildren<WeaponData>(true);

        foreach (var weapon in weapons)
        {
            if (weapon.gameObject.activeInHierarchy)
            {
              //  currentWeaponData = weapon;
                break;
            }
        }
    }
    private void Update()
    {
        /*   
           if (Input.GetButtonDown("Fire1"))
           {
   /*
               var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, fpsCam.transform.rotation);
               Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
              // var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.LookRotation(screenCenter, Vector3.forward));
               bullet.GetComponent<Rigidbody>().velocity = fpsCam.transform.up * bulletSpeed;

*/
        /*
               Vector3 mouseWorldPosition = Vector3.zero;
               Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
               Ray ray = fpsCam.ScreenPointToRay(screenCenter);
               if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderMask))
               {
                   mouseWorldPosition = raycastHit.point;
                  // debugTransform.position = raycastHit.point;
               }
               for (int i = 0; i < bulletSpawnPoint.Count; i++)
               {
                   Vector3 aimDir = (mouseWorldPosition - bulletSpawnPoint[i].position);
                   var bullet = Instantiate(bulletPrefab, bulletSpawnPoint[i].position, Quaternion.LookRotation(aimDir, Vector3.up));
                   bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
               }

              // Vector3 aimDir = (mouseWorldPosition - bulletSpawnPoint.position).normalized;
              // var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.LookRotation(aimDir, Vector3.up));
              //  bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

   

    } 
    */


        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (LoadGun.g1)
                Pistol();
            if (LoadGun.g2)
                ShotGun();
            if (LoadGun.g3)
                AutomaticGun();
        }


        /*
        if (Input.GetButtonDown("Fire1"))
            ShotGun();
        */
    }


    public void AutomaticGun()
    {
        if (Time.time - lastTimeFired > 1 / fireRate)
        {
            // AudioSource.Play();
            cameraRotation.Recoil();
            lastTimeFired = Time.time;
            Vector3 mouseWorldPosition = Vector3.zero;
            Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
            Ray ray = fpsCam.ScreenPointToRay(screenCenter);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderMask))
            {
                mouseWorldPosition = raycastHit.point;
                // debugTransform.position = raycastHit.point;
            }
            Vector3 aimDir = (mouseWorldPosition - bulletSpawnPoint[0].position).normalized;
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint[0].position, Quaternion.LookRotation(aimDir, Vector3.up));
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
            // Добавить отдачу
        }
    }

    public void ShotGun()
    {
        
        if (Time.time - lastTimeFired > 1 / fireRate)
        {

            /*   lastTimeFired = Time.time;
               cameraRotation.Recoil();
               Vector3 mouseWorldPosition = Vector3.zero;

               Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
               Ray ray = fpsCam.ScreenPointToRay(screenCenter);
               if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderMask))
               {
                   mouseWorldPosition = raycastHit.point;
                   // debugTransform.position = raycastHit.point;
               }
               int r = Random.Range(3, bulletSpawnPoint.Count);
               for (int i = 0; i < r; i++)
               {
                   Vector3 rnd = new Vector3(Random.Range(-scatter* 2, scatter * 2), Random.Range(-scatter * 2, scatter * 2), Random.Range(-scatter * 2, scatter * 2));
                   Vector3 aimDir = (mouseWorldPosition - bulletSpawnPoint[i].position - rnd + bulletSpawnPoint[i].forward).normalized;
                   // var bullet = Instantiate(bulletPrefab,aimDir, Quaternion.LookRotation(bulletSpawnPoint[i].forward));
                   var bullet = Instantiate(bulletPrefab, bulletSpawnPoint[i].position, Quaternion.LookRotation(bulletSpawnPoint[i].position));
                   bullet.GetComponent<Rigidbody>().velocity = aimDir * bulletSpeed;
               }
            */

            lastTimeFired = Time.time;
            cameraRotation.Recoil();

            Vector3 targetPoint;

            // Центр экрана
            Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
            Ray ray = fpsCam.ScreenPointToRay(screenCenter);

            // Определяем точку прицеливания
            if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderMask))
            {
                targetPoint = raycastHit.point;
            }
            else
            {
                // Если никуда не попали — стреляем вперёд
                targetPoint = ray.origin + ray.direction * 100f;
            }

            // Сколько дробин вылетит
            int r = Random.Range(3, bulletSpawnPoint.Count);

            for (int i = 0; i < r; i++)
            {
                Transform spawn = bulletSpawnPoint[i];

                // Базовое направление в точку прицеливания
                Vector3 baseDirection = (targetPoint - spawn.position).normalized;

                // Угловой разброс
                float angle = Random.Range(0f, scatter);
                float rotation = Random.Range(0f, 360f);

                Quaternion spreadRotation =
                    Quaternion.AngleAxis(angle, fpsCam.transform.right) *
                    Quaternion.AngleAxis(rotation, fpsCam.transform.forward);

                Vector3 finalDirection = spreadRotation * baseDirection;

                // Создание пули
                var bullet = Instantiate(
                    bulletPrefab,
                    spawn.position,
                    Quaternion.LookRotation(finalDirection)
                );

                bullet.GetComponent<Rigidbody>().velocity = finalDirection * bulletSpeed;
            }
        }


       

        }
    public void Pistol()
    {
        if (Time.time - lastTimeFired > 1 / fireRate)
        {
            // AudioSource.Play();
            cameraRotation.Recoil();
            lastTimeFired = Time.time;
            Vector3 mouseWorldPosition = Vector3.zero;
            Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
            Ray ray = fpsCam.ScreenPointToRay(screenCenter);
            if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderMask))
            {
                mouseWorldPosition = raycastHit.point;
                // debugTransform.position = raycastHit.point;
            }
            Vector3 aimDir = (mouseWorldPosition - bulletSpawnPoint[0].position).normalized;
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint[0].position, Quaternion.LookRotation(aimDir, Vector3.up));
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
            
        }

    }

    
}