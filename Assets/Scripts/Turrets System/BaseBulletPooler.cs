using System.Collections.Generic;
using UnityEngine;

public class BaseBulletPooler : MonoBehaviour
{
    public static BaseBulletPooler SharedInstance;
    public List<GameObject> pooledObjects;
    public List<IBullet> pooledBullets;
    public GameObject objectToPool;
    public int amountToPool;

    void Awake()
    {
        SharedInstance = this;
        pooledObjects = new List<GameObject>();
        pooledBullets = new List<IBullet>();
        for (int i = 0; i < amountToPool; i++)
        {
            CreatePooledObject();
        }
    }

    private void CreatePooledObject()
    {
        GameObject tmp = Instantiate(objectToPool);
        tmp.SetActive(false);
        pooledObjects.Add(tmp);

        IBullet bullet = tmp.GetComponent<IBullet>();
        if (bullet != null)
        {
            pooledBullets.Add(bullet);
        }
        
    }

    public (GameObject, IBullet) GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return (pooledObjects[i], pooledBullets[i]);
            }
        }
        CreatePooledObject();
        return (pooledObjects[^1], pooledBullets[pooledBullets.Count - 1]);
    }
}
