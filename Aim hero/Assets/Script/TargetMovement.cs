using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    private Vector3 moveSpeed;
    private CharacterController characterController;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    } 

    private void Update()
    { 
        characterController.Move(moveSpeed*Time.deltaTime);
    }
    public void MoveTo(Vector3 direction)
    {
        moveSpeed = direction;
    }
}
