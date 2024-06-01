using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooler : MonoBehaviour
{
    public static EnemyPooler SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;
    private int enemiesToActivate;

    void Awake()
    {
        SharedInstance = this;
        enemiesToActivate = 1; 
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            tmp.transform.position = transform.position;
            pooledObjects.Add(tmp);
        }
    }

    void ExpandPool()
    {
        GameObject newObj = Instantiate(objectToPool);
        newObj.SetActive(false);
        newObj.transform.position = transform.position;
        pooledObjects.Add(newObj);
    }

    public GameObject GetPooledObject()
    {
        foreach (var objToPull in pooledObjects)
        {
            if (!objToPull.activeInHierarchy)
            {
                return objToPull;
            }
        }
        GameObject newObject = Instantiate(objectToPool);
        pooledObjects.Add(newObject);
        return newObject;
    }

    public bool AllEnemiesDisabled()
    {
        foreach (var obj in pooledObjects)
        {
            if (obj.activeInHierarchy)
                return false;
        }
        return true;
    }

    public void IncreaseEnemiesToActivate()
    {
        enemiesToActivate++;
        ExpandPool();
    }

    public void ActivateEnemies()
    {
        int activated = 0;
        foreach (var obj in pooledObjects)
        {
            if (!obj.activeInHierarchy && activated < enemiesToActivate)
            {
                obj.SetActive(true);
                activated++;
            }
        }
        
    }
}
