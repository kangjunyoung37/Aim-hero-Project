using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Input KeyCodes")]
    [SerializeField]
    private KeyCode keyCodeRun = KeyCode.LeftShift;//달리기 키를 입력받았을때
    [SerializeField]
    private KeyCode keyCodeJump = KeyCode.Space;
    [SerializeField]
    private AudioClip runAudioClip;
    [SerializeField]
    private AudioClip walkAudioClip;

    private AudioSource audioSource;//사운드 재생 컴포넌트
    private RotateMouse rotateMouse;
    private MovementCharacterController movementCharacterController;
    private Status status;
    private PlayeranimatorController playerAnimatorController;
    private WeaponHandGun weapon;

    

    private void Awake()
    {
        status = GetComponent<Status>();
        movementCharacterController = GetComponent<MovementCharacterController>();
        rotateMouse = GetComponent<RotateMouse>();
        playerAnimatorController = GetComponent<PlayeranimatorController>();
        audioSource = GetComponent<AudioSource>();
        weapon = GetComponentInChildren<WeaponHandGun>();
        Cursor.lockState = CursorLockMode.Locked;//마우스 위치를 고정 및 커서를 안보이게 설정
        Cursor.visible = false;
    }
    private void Update()
    {
        UpdateRotate();
        UpdateMovement();
        UpdateJump();
        UpdateWeaponAction();
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
            playerAnimatorController.MoveSpeed = isRun ? 1 : 0.5f;//애니메이터 컨트롤러의 파라미터를 뛰는 상태면 1 아니면 0.5로 바꿈
            audioSource.clip = isRun ? runAudioClip : walkAudioClip;
            if (audioSource.isPlaying == false)
            {
                audioSource.loop = true;
                audioSource.Play();
            }
        }
        else
        {
            movementCharacterController.MoveSpeed = 0;
            playerAnimatorController.MoveSpeed = 0;
            if(audioSource.isPlaying == true)
            {
                audioSource.Stop();
            }
        }
        movementCharacterController.MoveTo(new Vector3(x, 0, z));
    }
    private void UpdateJump()
    {
        if (Input.GetKeyDown(keyCodeJump))
        {
            movementCharacterController.Jump();
        }
    }
    private void UpdateWeaponAction()
    {
        if (Input.GetMouseButtonDown(0))//왼쪽 버튼을 눌렀을 때
        {
            weapon.StartWeaponAction();
        }
        else if (Input.GetMouseButtonUp(0))//왼쪽 버튼을 땠을 때
        {
            weapon.StopWeaponAction();
        }
    }
}
