using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]//캐릭터 컨트롤러 컴포넌트를 필요로 함
public class MovementCharacterController : MonoBehaviour
{
    private CharacterController characterController;
    
    [SerializeField]
    private float moveSpeed;
    private Vector3 moveForce;
    
    public float MoveSpeed
    {
        set => moveSpeed = Mathf.Max(0, value);//속도가 음수가 적용되지 않도록 Max를 사용
        get => moveSpeed;
    }
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    

    private void Update()
    {
        characterController.Move(moveForce*Time.deltaTime);//1초당 moveForce 속력으로 이동
    }
    public void MoveTo(Vector3 direction)
    {
        direction = transform.rotation * new Vector3(direction.x, 0, direction.z);
        moveForce = new Vector3(direction.x * moveSpeed, moveForce.y, direction.z * moveSpeed);

    }
}
