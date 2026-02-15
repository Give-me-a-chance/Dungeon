using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Assets.Scripts;

public class ImproveBar : MonoBehaviour
{
    public Canvas canvas;
    public Button FireRateBtn;
    public TextMeshProUGUI FireRateText;
    public Button DamageBtn;
    public TextMeshProUGUI DamageText;
    public Button RecoilBtn;
    public TextMeshProUGUI RecoilText;
    public Button BulettSpeedBtn;
    public TextMeshProUGUI BulletSpeedText;
    private float DamageBuff;
    private float FireRateBuff;
    private float RecoilBuff;
    private float BulletSpeedBuff;
    public GameObject panel;


    public Camera fpsCam;
    public CameraRotation cameraRotation;

    public Transform gun;
    public ShootWithBullet shooting;

    public Transform bullet;
    public BulletProjectile projectile;

    public void Start()
    {
        GlobalEventManager.PanelActive = PanelActive;
    }
    public void PanelActive()
    {
        GlobalEventManager.PanelActive += PanelActive;
        panel.SetActive(true);
        Info();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }    
    public void Info()
    {
        Time.timeScale = 0f;
        DamageBuff = Random.Range(5, 20);
        FireRateBuff = Random.Range(5, 20);
        RecoilBuff = Random.Range(5, 20);
        BulletSpeedBuff = Random.Range(5, 20);
        FireRateText.text = $"Увеличение скорострельности на {FireRateBuff}%";
        DamageText.text = $"Увеличение урона на {DamageBuff}%";
        RecoilText.text = $"Уменьшение отдачи на {RecoilBuff}%";
        BulletSpeedText.text = $"Увеличение скорости пули на {BulletSpeedBuff}%";
        
        cameraRotation = fpsCam.GetComponent<CameraRotation>();
        shooting = gun.GetComponent<ShootWithBullet>();
        projectile = bullet.GetComponent<BulletProjectile>();

    }

    public void Damage_click()
    {
        projectile.damage += projectile.damage / 100 * DamageBuff;
        Time.timeScale = 1f;
        panel.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void FireRate_click() 
    {
        shooting.fireRate += shooting.fireRate / 100 * FireRateBuff;
        Time.timeScale = 1f;
        panel.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Recoil_click()
    {
        cameraRotation.offsetX -= cameraRotation.offsetX / 100 * RecoilBuff;
        cameraRotation.offsetY -= cameraRotation.offsetY / 100 * RecoilBuff;
        Time.timeScale = 1f;
        panel.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void BulletSpeed_click()
    {
        shooting.bulletSpeed += shooting.bulletSpeed / 100 * BulletSpeedBuff;
        Time.timeScale = 1f;
        panel.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }






}
