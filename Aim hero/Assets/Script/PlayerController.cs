using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private RotateMouse rotateMouse;

    private void Awake()
    {
        rotateMouse = GetComponent<RotateMouse>();
        Cursor.lockState = CursorLockMode.Locked;//마우스 위치를 고정 및 커서를 안보이게 설정
        Cursor.visible = false;
    }
    private void Update()
    {
        UpdateRotate();
    }
    private void UpdateRotate()
    {
        float MouseX = Input.GetAxis("Mouse X");
        float MouseY = Input.GetAxis("Mouse Y");
        Debug.Log(MouseX);
        Debug.Log(MouseY);
        rotateMouse.UpdateRotate(MouseX, MouseY);
    }
}
