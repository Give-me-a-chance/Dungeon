using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigibodyMovement : PLayerMove
{
    private new Rigidbody rigidbody;
    private void Start() => rigidbody = GetComponent<Rigidbody>();

    private void FixedUpdate() => rigidbody.MovePosition(transform.position + _movementVector * _movementSpeed * Time.fixedDeltaTime);
    
    



}
