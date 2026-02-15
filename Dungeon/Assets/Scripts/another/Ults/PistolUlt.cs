using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolUlt : MonoBehaviour
{

    public List<Transform> bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public Camera fpsCam;
    // [SerializeField] private Transform debugTransform;
    [SerializeField] private LayerMask aimColliderMask;
    public Transform aimCamera;
    public CameraRotation cameraRotation;
    private void Start()
    {
        cameraRotation = fpsCam.GetComponent<CameraRotation>();
    }
    // Update is called once per frame
    void Update()
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
        Vector3 aimDir = (mouseWorldPosition - bulletSpawnPoint[0].position).normalized;
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint[0].position, Quaternion.LookRotation(aimDir, Vector3.forward));
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
    }
}
