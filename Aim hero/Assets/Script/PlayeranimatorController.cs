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

}
