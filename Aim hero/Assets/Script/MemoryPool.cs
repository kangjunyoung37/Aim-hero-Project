using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryPool
{   
    private class Pooltem
    {
        public bool isActive;
        public GameObject gameObject;
    }
    private int increaseCount = 5;
    private int maxCount;
    private int activeCount;

    public GameObject poolObject;
    private List<Pooltem> poolItemList;

    public int MaxCount => maxCount;
    public int ActiveCOunt => activeCount;

    public MemoryPool(GameObject poolObject)
    {
        maxCount = 0;
        activeCount = 0;
        this.poolObject = poolObject;
        poolItemList = new List<Pooltem>();
        InstantivateObject();
    }
    public void InstantivateObject()
    {
        maxCount += increaseCount;
        for (int i = 0; i < increaseCount; i++)
        {

        Pooltem pooltem = new Pooltem();

        pooltem.isActive = false;
        pooltem.gameObject = GameObject.Instantiate(poolObject);
        pooltem.gameObject.SetActive(false);

        poolItemList.Add(pooltem);
        }
    }
    public void DestroyObjects()//모든 오브젝트를 삭제
    {
        if (poolItemList == null) return;
        for (int i = 0; i < poolItemList.Count; i++)
        {
            GameObject.Destroy(poolItemList[i].gameObject);
        }
        poolItemList.Clear();
    }
    public GameObject ActivatePoolItem()//poolItme 활성화시키기
    {
        if(poolItemList == null) return null;
        if (maxCount == activeCount)
            InstantivateObject();
        int count = poolItemList.Count;
        for (int i = 0; i < count; i++)
        {
            Pooltem pooltem = poolItemList[i];
            if (pooltem.isActive == false)
            {
                activeCount++;
                pooltem.isActive = true;
                pooltem.gameObject.SetActive(true);

                return pooltem.gameObject;

            }
        }
        return null;

    }
    public void DeactivatePoolItem(GameObject removeobject)
    {
        if (removeobject == null|| poolItemList == null) return;

        int count = poolItemList.Count;
        for (int i = 0; i < count; i++)
        {
            Pooltem pooltem = poolItemList[i];
            if (pooltem.gameObject == removeobject)
            {
                activeCount--;

                pooltem.isActive = false;
                pooltem.gameObject.SetActive(false);
                return;

            }
        }
    }
    public void DeactivteAllPoolItems()
    {
        if (poolItemList == null) return;

        int count = poolItemList.Count;
        for (int i = 0; i < count; i++)
        {
            Pooltem pooltem = poolItemList[i];

            if(pooltem !=null && pooltem.isActive == true)
            {

                pooltem.isActive = false;
                pooltem.gameObject.SetActive(false);
            }
        }
        activeCount = 0;
    }


}
