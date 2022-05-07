using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ImpactType { Noraml = 0, Obstacle,}
public class ImpactMemoryPool : MonoBehaviour
{
    [SerializeField]
    private GameObject[] impactPrefab;
    private MemoryPool[] memoryPool;

    private void Awake()
    {
        memoryPool = new MemoryPool[impactPrefab.Length];
        for (int i = 0; i < memoryPool.Length; i++)
        {
            memoryPool[i] = new MemoryPool(impactPrefab[i]);

        }
    }

    public void SpawnImpact(RaycastHit hit)
    {
        if(hit.transform.CompareTag("ImpactNormal"))
        {
            OnSpawnImpact(ImpactType.Noraml, hit.point, Quaternion.LookRotation(hit.normal));
            
        }
        else if (hit.transform.CompareTag("ImpactObastacle"))
        {
            OnSpawnImpact(ImpactType.Obstacle, hit.point,Quaternion.LookRotation(hit.normal));

        }
    }
    public void OnSpawnImpact(ImpactType type, Vector3 position, Quaternion rotation)
    {
        GameObject item = memoryPool[(int)type].ActivatePoolItem();
        item.transform.position = position;
        item.transform.rotation = rotation;
        item.GetComponent<Impact>().Setup(memoryPool[(int)type]);
    }
}
