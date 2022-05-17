using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMemoryPool : MonoBehaviour
{
    [SerializeField]
    private GameObject enemySpawnPointPrefab;
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float enemySpawnTime = 1;
    [SerializeField]
    private float enemySpawnLatency = 1;
    
    private MemoryPool spawnPointMemoryPool;
    private MemoryPool enemyMemoryPool;

    private Vector2Int mapsize = new Vector2Int(50, 50);

    private void Awake()
    {
        spawnPointMemoryPool = new MemoryPool(enemySpawnPointPrefab);
        enemyMemoryPool = new MemoryPool(enemyPrefab);

        StartCoroutine("SpawnTile");
    }
    private void Update()
    {
        
    }
    private IEnumerator SpawnTile()
    {
        int currentNumber = 0;
        int maxiumNumber = 5;

        while (true)
        {
            GameObject item = spawnPointMemoryPool.ActivatePoolItem();
            item.transform.position = new Vector3(Random.Range(-mapsize.x * 0.49f, mapsize.x * 0.49f), 1, Random.Range(-mapsize.y * 0.49f, mapsize.y * 0.49f));
            StartCoroutine("SpawnEnemy", item);
            currentNumber++;

            if(currentNumber >= maxiumNumber)
            {
                yield break;

            }
            yield return new WaitForSeconds(enemySpawnTime);
        }

    }
    private IEnumerator SpawnEnemy(GameObject point)
    {
        yield return new WaitForSeconds(enemySpawnLatency);

        GameObject item = enemyMemoryPool.ActivatePoolItem();
        item.transform.position = point.transform.position;

        spawnPointMemoryPool.DeactivatePoolItem(point);

        yield return new WaitForSeconds(enemySpawnLatency);
        enemyMemoryPool.DeactivatePoolItem(item);
        

    }

}
