using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{

    private TargetMovement targetMovement;

    
    private Vector3 movespeed;
    
    private int a;
    private float MoveTime = 3.0f;
   
    private void Awake()
    {
        targetMovement = GetComponent<TargetMovement>();
       
    }

    private IEnumerator Right()
    {

        yield return new WaitForSeconds(1f);
        MoveTime += 3.0f;
        


    }
    private void Update()
    {
        movespeed = new Vector3(2, 0, 0);
        if (Time.time < MoveTime)
        {
              
            transform.position += movespeed * Time.deltaTime;

        }
        
        
    }

}
