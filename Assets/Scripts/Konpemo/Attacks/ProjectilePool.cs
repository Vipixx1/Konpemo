using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    public static ProjectilePool SharedInstance;

    [SerializeField]
    private Projectile objectToPool;

    private List<Projectile> pooledObjects;
    private int amountToPool = 1;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<Projectile>();
        Projectile tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.gameObject.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }
    
    public Projectile GetPooledObject()
    {
        for(int i = 0; i < amountToPool; i++)
        {
            if(!pooledObjects[i].gameObject.activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        Projectile tmp = Instantiate(objectToPool);
        pooledObjects.Add(tmp);
        amountToPool++;
        return tmp;
    }
}
