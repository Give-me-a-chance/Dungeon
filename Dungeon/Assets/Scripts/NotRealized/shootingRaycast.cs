using UnityEngine;

public class shootingRaycast : MonoBehaviour
{
    [SerializeField]
    public float damage;
    [SerializeField]
    public float range;
    public Camera fpsCam;
    [SerializeField] private LayerMask aimColliderMask;
    [SerializeField] private Transform debugTransform;
    [SerializeField] private Transform spawnbulletPosition;
    [SerializeField] private Transform pfbullet;
    void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 aimDir = (mouseWorldPosition - spawnbulletPosition.position).normalized;
            Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
            Instantiate(pfbullet, spawnbulletPosition.position, Quaternion.LookRotation(screenCenter, Vector3.forward));
            
        }
    }

    private void Shoot()
    {
        /*
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
            Debug.Log(hit.transform.name);
        */
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenter = new Vector2(Screen.width /2, Screen.height / 2);
        Ray ray = fpsCam.ScreenPointToRay(screenCenter);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 100f, aimColliderMask))
        {
            mouseWorldPosition = raycastHit.point;
            debugTransform.position = raycastHit.point;
        }

    }
}
