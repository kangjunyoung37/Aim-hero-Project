using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private RotateMouse rotateMouse;
    private MovementCharacterController movementCharacterController;
    private void Awake()
    {
        movementCharacterController = GetComponent<MovementCharacterController>();
        rotateMouse = GetComponent<RotateMouse>();
        Cursor.lockState = CursorLockMode.Locked;//마우스 위치를 고정 및 커서를 안보이게 설정
        Cursor.visible = false;
    }
    private void Update()
    {
        UpdateRotate();
        UpdateMovement();
    }
    private void UpdateRotate()
    {
        float MouseX = Input.GetAxis("Mouse X");
        float MouseY = Input.GetAxis("Mouse Y");
        Debug.Log(MouseX);
        Debug.Log(MouseY);
        rotateMouse.UpdateRotate(MouseX, MouseY);
    }
    private void UpdateMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        movementCharacterController.MoveTo(new Vector3(x, 0, z));
    }
}
