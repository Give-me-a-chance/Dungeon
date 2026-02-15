using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SgUlt : MonoBehaviour
{
    // Start is called before the first frame update
    


    public List<Transform> bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public Camera fpsCam;
    [SerializeField] private LayerMask aimColliderMask;
    public Transform aimCamera;
    public CameraRotation cameraRotation;
    
    public void Start()
    {
        cameraRotation = fpsCam.GetComponent<CameraRotation>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            Ult();
    }
    public void Ult()
    {
        cameraRotation.Recoil();
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
            Vector3 rnd = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
            Vector3 aimDir = (mouseWorldPosition - bulletSpawnPoint[i].position - rnd + bulletSpawnPoint[i].forward).normalized;
            // var bullet = Instantiate(bulletPrefab,aimDir, Quaternion.LookRotation(bulletSpawnPoint[i].forward));
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint[i].position, Quaternion.LookRotation(bulletSpawnPoint[i].position));
            bullet.GetComponent<Rigidbody>().velocity = aimDir * bulletSpeed;
        }
    }
}
