using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    private int x = 1;
    private int z = 1;
    private TargetMovement targetMovement;
    private void Awake()
    {
        targetMovement = GetComponent<TargetMovement>();
    }
    IEnumerator Direction()
    {
        yield return new WaitForSeconds(1.5f);
        x = Random.Range(-1, 1);
        z = Random.Range(-1, 1);
    }
    private void Update()
    {
        StartCoroutine(Direction());
        targetMovement.MoveTo(new Vector3(x, 0, z));
    }

}
