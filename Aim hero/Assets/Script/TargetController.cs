using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{

    private TargetMovement targetMovement;

    [SerializeField]
    private Transform target;
    
    private Vector3 movespeed = new Vector3(7, 0, 0);

    private float MoveTime = 2.0f;
    private float LastTime = 0;
   
    private void Awake()
    {
        targetMovement = GetComponent<TargetMovement>();
       
    }

    private Vector3 patern(int num)
    {
        switch (num)
        {
            case 0:
                Vector3 right = new Vector3(5, 0, 0);
            return right;
                
            case 1:
                Vector3 left = new Vector3(-5, 0, 0);
                return left;

            
            case 2:
                Vector3 rightcorss = new Vector3(5, 0, 4);
                return rightcorss;

            case 3:
                Vector3 leftcorss = new Vector3(-5, 0, -4);
                return leftcorss;            
        }
        return Vector3.zero;
        
    }
    private IEnumerator Wait()
    {

        movespeed = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(0.5f);
        LastTime = Time.time;
  
    }
    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 90);
        transform.LookAt(target.position);
        if (Time.time - LastTime <= MoveTime)
        {
            transform.position += movespeed * Time.deltaTime;
        }
        else
        {
            StartCoroutine(Wait());
            int randomnum = Random.Range(0, 4);
            movespeed = patern(randomnum);
        }
        

    }

}
