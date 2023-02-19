using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowPool : MonoBehaviour
{
    public static ShadowPool instance;
    public GameObject shadowPrefab;
    public int shadowCount;
    //队列
    private Queue<GameObject> availableObjects = new Queue<GameObject>();

    private void Awake()
    {
        instance = this;
        FillPool();
    }
    public void FillPool()
    {
        for(int i=0;i<shadowCount;i++)
        {
            var newShadow = Instantiate(shadowPrefab);
            newShadow.transform.SetParent(transform);
            //返回对象池
            ReturnPool(newShadow);
        }
    }
    //返回对象池
    public void ReturnPool(GameObject gameObject)
    {
        gameObject.SetActive(false);

        availableObjects.Enqueue(gameObject);
    }
    //从对象池里拿出幻影
    public GameObject GetFormPool()
    {
        //不够用
        if(availableObjects.Count==0)
        {
            FillPool();
        }
        var outShadow = availableObjects.Dequeue();
        outShadow.SetActive(true);
        return outShadow;
    }

}
