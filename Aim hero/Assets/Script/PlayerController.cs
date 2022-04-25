using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Input KeyCodes")]
    [SerializeField]
    private KeyCode keyCodeRun = KeyCode.LeftShift;//달리기 키를 입력받았을때

    private RotateMouse rotateMouse;
    private MovementCharacterController movementCharacterController;
    private Status status;

    

    private void Awake()
    {
        status = GetComponent<Status>();
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
        if (x != 0 || z != 0)//이동중일 때 걷거나 뛰기 중일때
        {
            bool isRun = false;

            if (z > 0) isRun = Input.GetKey(keyCodeRun);
            movementCharacterController.MoveSpeed = isRun ? status.RunSpeed : status.WalkSpeed; //isRun이 트루면 뛰는속도로 아니면 걷는 속도로

        }
        movementCharacterController.MoveTo(new Vector3(x, 0, z));
    }
}
