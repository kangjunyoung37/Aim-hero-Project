using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandGun : MonoBehaviour
{
    [Header("Audio Clips")]
    [SerializeField]
    private AudioClip audioTakeOutWeapon;

    private AudioSource audioSource;
    private PlayeranimatorController animator;

    [SerializeField]
    private WeaponSetting weaponSetting;

    [SerializeField]
    private GameObject muzzleFalsh;
    [SerializeField]
    private AudioClip FireSound;

    private float lastAttackTime = 0;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>(); 
        animator = GetComponentInParent<PlayeranimatorController>();

    }
 
    public void StartWeaponAction(int type = 0)
    {
        //마우스 왼쪽 클릭
        if (type == 0)
        {
            if(weaponSetting.isAutomaticAttack == true)//연발
            {
                StartCoroutine("OnAttackLoop");
            }
            else//단발
            {
                OnAttack();
            }
        }
    }
    public void StopWeaponAction(int type = 0)
    {
        if(type == 0)//공격 중지
        {
            StopCoroutine("OnAttackLoop");
        }
    }
    private IEnumerator OnAttackLoop()//자동공격
    {
        while (true)
        {
            OnAttack();
            yield return null;
        }

    }
    private void OnAttack()
    {
        if(Time.time-lastAttackTime > weaponSetting.attackRate)
        {
            if(animator.MoveSpeed > 0.5f)//뛰고 있을 때 공격 X
            {
                return;
            }

            lastAttackTime = Time.time;//공격주기가 되어야 공격할 수 있도록 현재 시간 저장
            animator.Play("Fire", -1, 0);//같은 애니메이션을 반복할 때 애니메이션을 끊고 처음부터 재생
            PlaySound(FireSound);
            StartCoroutine("OnMuzzel");
        }
    }
    private IEnumerator OnMuzzel()
    {
        muzzleFalsh.SetActive(true);
        yield return new WaitForSeconds(weaponSetting.attackRate*0.3f);
        muzzleFalsh.SetActive(false);
    }
    private void OnEnable()
    {
        muzzleFalsh.SetActive(false);//총구 화염을 안보이게
        PlaySound(audioTakeOutWeapon);
    }
    private void PlaySound(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }
 

}
