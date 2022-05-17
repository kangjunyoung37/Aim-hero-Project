using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TargetController : MonoBehaviour
{

    [SerializeField]
    private Transform player;
    
    private Vector3 distance = new Vector3(-5, 0, 0);

    [Range(0,100)]
    [SerializeField]
    private float speed = 1.0f;

    private float MoveTime = 1.0f;
    private float LastTime = 0;
   
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

        distance = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(0.5f);
        LastTime = Time.time;
  
    }
    private void Update()
    {
      
        transform.LookAt(new Vector3(player.position.x, 1.5f, player.position.z));
        
        if (Time.time - LastTime <= MoveTime)
        {
            if (-25 < (transform.position.x + distance.x)
               &&  25 > (transform.position.x + distance.x) 
               && (transform.position.z + distance.z) < 25
               && (transform.position.z + distance.z) > -25)
            {

                transform.position += (distance * speed) * Time.deltaTime;
            }
            else
            {
                int randomnum = Random.Range(0, 4);
                distance = patern(randomnum);
            }
            
        }
        else
        {
            StartCoroutine(Wait());
            int randomnum = Random.Range(0, 4);
            distance = patern(randomnum);
        }
        

    }

}
