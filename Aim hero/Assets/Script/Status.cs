using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float runSpeed;
    [SerializeField]
    private float score;


    public float WalkSpeed => walkSpeed;
    public float RunSpeed => runSpeed;

    public float Score
    {
        get  { return score; }
        set  { score = value; }
    }

}
