using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;
    public List<GameObject> pooledObjects;
    public List<Bullet> pooledBullets;
    public GameObject objectToPool;
    public int amountToPool;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        pooledBullets = new List<Bullet>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
            pooledBullets.Add(tmp.GetComponent<Bullet>());
        }
        
    }
    public (GameObject, Bullet) GetPooledObject()
    {
        for (int i = 0;i < pooledObjects.Count;i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                
                return (pooledObjects[i], pooledBullets[i]);
            }
        }
        GameObject newObject = Instantiate(objectToPool);
        Bullet newBullet = newObject.GetComponent<Bullet>();
        pooledObjects.Add(newObject);
        pooledBullets.Add(newBullet);
       
        return (newObject, newBullet);

    }
}