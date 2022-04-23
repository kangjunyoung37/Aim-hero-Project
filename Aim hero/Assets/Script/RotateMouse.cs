using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMouse : MonoBehaviour
{
    [SerializeField]
    private float rotCamXAxixSpeed = 5; //X축 회전 속도
    [SerializeField]
    private float rotCamYAxixSpeed = 3;//Y축 회전 속도

    private float limitMinX = -80;//카메라 X축 최소 회전 범위
    private float limitMaxX = 80;//카메라 X축 최대 회전 범위
    private float eulerAngleX;
    private float eulerAngleY;

    public void UpdateRotate(float mouseX, float mouseY)
    {
        eulerAngleY += mouseX* rotCamXAxixSpeed;//마우스 좌/우 이동으로 카메라 Y축 회전
        eulerAngleX -= mouseY* rotCamYAxixSpeed;//마우스 상/하 이동으로 카메라 X축 회전

        eulerAngleX = ClampAngle(eulerAngleX, limitMinX, limitMaxX);//카메라 X축의 회전 범위를 설정
        transform.rotation = Quaternion.Euler(eulerAngleX, eulerAngleY, 0);
    }
    public float ClampAngle(float angle, float min , float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;
        return Mathf.Clamp(angle, min, max);

    }

}
