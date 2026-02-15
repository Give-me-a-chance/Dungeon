using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGun : MonoBehaviour
{
    public static bool g1;
    public static bool g2;
    public static bool g3;
    public GameObject gun1;
    public GameObject gun2;
    public GameObject gun3;

    public Transform gunt1;
    public Transform gunt2;
    public Transform gunt3;
    public WeaponData shooting;


    public Transform bulletPistol;
    public BulletProjectile projectile1;

    public Transform bulletShotgun;
    public BulletProjectile projectile2;

    public Transform bulletAR;
    public BulletProjectile projectile3;

    public ShootingWeapons shootingWeapons;

    public void Start()
    {
       if (PlayerPrefs.HasKey("SelectedGun"))
        {
            if (PlayerPrefs.GetInt("SelectedGun") == 1)
            {
                Destroy(gun2);
                Destroy(gun3);
                g1 = true;
                g2 = false;
                g3 = false;
                projectile1 = bulletPistol.GetComponent<BulletProjectile>();
                if (Stats.LvlsP.Split(' ')[0] == "1")
                    projectile1.damage = 10;             
                else
                    projectile1.damage = 10 + 5 * int.Parse(Stats.LvlsP.Split(' ')[0]);

                shooting = gunt1.GetComponent<WeaponData>();
                if (Stats.LvlsP.Split(' ')[1] == "1")
                    shooting.fireRate = (float)3;
                else
                    shooting.fireRate = (float)(decimal.Round((decimal)(3 + int.Parse(Stats.LvlsP.Split(' ')[1]) * 0.15), 2));
           //     Debug.Log(projectile1.damage);
             //   Debug.Log(shooting.fireRate);
                shootingWeapons.currentWeaponData = gun1.GetComponent<WeaponData>();


            }
            if (PlayerPrefs.GetInt("SelectedGun") == 2)
            {
                Destroy(gun1);
                Destroy(gun3);
                g1 = false;
                g2 = true;
                g3 = false;
                if (Stats.LvlsSG.Split(' ')[0] == "1")
                    ShootWithBullet.scatter = 8;
                else
                    ShootWithBullet.scatter = (float)(8 - int.Parse(Stats.LvlsSG.Split(' ')[0]));
                if (Stats.LvlsSG.Split(' ')[1] == "1")
                    shootingWeapons.bulletSpeed = 40;
                else
                    shootingWeapons.bulletSpeed = (float)(40 + int.Parse(Stats.LvlsSG.Split(' ')[0]) * 6);
              //  Debug.Log(shooting.bulletSpeed);
               // Debug.Log(ShootWithBullet.scatter);
                shootingWeapons.currentWeaponData = gun2.GetComponent<WeaponData>();

            }
            if (PlayerPrefs.GetInt("SelectedGun") == 3)
            {
                Destroy(gun1);
                Destroy(gun2);
                g1 = false;
                g2 = false;
                g3 = true;
                projectile1 = bulletAR.GetComponent<BulletProjectile>();
                if (Stats.LvlsAR.Split(' ')[0] == "1")
                    projectile1.damage = 30;
                else
                    projectile1.damage = 20 + 5 * int.Parse(Stats.LvlsAR.Split(' ')[0]);
                shooting = gunt3.GetComponent<WeaponData>();
                if (Stats.LvlsAR.Split(' ')[1] == "1")
                    shooting.fireRate = (float)2;
                else
                    shooting.fireRate = (float)(decimal.Round((decimal)(2 + int.Parse(Stats.LvlsAR.Split(' ')[1]) * 0.4), 2));
                Debug.Log(projectile1.damage);
                Debug.Log(shooting.fireRate);
                shootingWeapons.currentWeaponData = gun3.GetComponent<WeaponData>();
            }

        }
       else
        {
            Destroy(gun2);
            Destroy(gun3);
            g1 = true;
            g2 = false;
            g3 = false;
        }

    }
}
