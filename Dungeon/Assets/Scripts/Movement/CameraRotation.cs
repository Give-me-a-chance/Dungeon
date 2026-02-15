using Unity.VisualScripting;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField]
    public Camera _aimCamera;
   // [SerializeField]
  //  private Transform _withscope;
  //  [SerializeField]
   // private Transform _withoutScope;
    
    [SerializeField]
    protected float _sensitivity = 2.5f;
    
    
    [SerializeField]
    protected float _smooth = 10;
   
    [SerializeField]
    protected Transform _character;
    
    
    [SerializeField]
    public Transform _gun;

    public Transform _gun2;

    public Transform _gun3;
   
    
    public float xRotation;
    public float yRotation;
    public float offsetX;
    public float offsetY;

    
   // private bool inScope;


    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
       // inScope = false;
        
    }

    public void Update()
    {

        if (_character == null) return;

        yRotation += Input.GetAxis("Mouse X") * _sensitivity;
        xRotation -= Input.GetAxis("Mouse Y") * _sensitivity;

        xRotation = Mathf.Clamp(xRotation, -90f, 45f);

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(xRotation, yRotation, 0), Time.deltaTime * _smooth);
        _character.rotation = Quaternion.Lerp(_character.rotation, Quaternion.Euler(0, yRotation, 0), Time.deltaTime * _smooth);

        // 2. Проверяем пушки перед вращением
        if (_gun != null && _gun.gameObject.activeSelf)
            _gun.rotation = Quaternion.Lerp(_gun.rotation, Quaternion.Euler(xRotation, yRotation, 0), Time.deltaTime * _smooth);

        if (_gun2 != null && _gun2.gameObject.activeSelf)
            _gun2.rotation = Quaternion.Lerp(_gun2.rotation, Quaternion.Euler(xRotation, yRotation, 0), Time.deltaTime * _smooth);

        if (_gun3 != null && _gun3.gameObject.activeSelf)
            _gun3.rotation = Quaternion.Lerp(_gun3.rotation, Quaternion.Euler(xRotation, yRotation, 0), Time.deltaTime * _smooth);


        /*   
           if (Input.GetButtonDown("Fire1"))
           {
               PLayerMove player = new PLayerMove();
               if (inScope == false)
               {
                   _aimCamera.transform.position = _withscope.position;
                   inScope = true;
                 //  player._movementSpeed = 6;
   }
               else
               {
                   _aimCamera.transform.position = _withoutScope.position;
                   inScope = false;
                // player._movementSpeed = 12;
               }
           }
           */



    }
    public void Recoil()
    {
        xRotation -= offsetX;
        yRotation += Random.Range(-offsetY, offsetY);
    }
   

    
}
