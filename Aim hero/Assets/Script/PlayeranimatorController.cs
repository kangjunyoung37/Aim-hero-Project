using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeranimatorController : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();  
    }
    public float MoveSpeed
    {
        set => animator.SetFloat("MovementSpeed", value);
        get => animator.GetFloat("MovementSpeed");
   
    }
    public void OnReload()
    {
        animator.SetTrigger("OnReload");
    }
    public void Play(string statename ,int layer, float normailizedTime )//외부에서 호출할 수 있도록 Play 함수를 선언해준다
    {
        animator.Play(statename,layer,normailizedTime);
    } 
    public bool CurrentAnimationIs(string name)
    {
        return animator.GetCurrentAnimatorStateInfo(0).IsName(name);
    }

}
