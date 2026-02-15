using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerMove : MonoBehaviour
{
    [SerializeField]
    
    public bool IsActive;
    public float _movementSpeed;
    protected Vector3 _movementVector;
    public bool isGrounded;
    
    
    private void OnCollisionEnter()
    {
        isGrounded = true;
        IsActive = true;
    }
    protected void Update() 
    { 
        _movementVector = transform.right * Input.GetAxis("Horizontal") + Input.GetAxis("Vertical") * transform.forward ;
        

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
             isGrounded = false;
             GetComponent<Rigidbody>().AddForce(new Vector3(0, 200, 0));  
        }
        

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            
        }
    }
    

}
