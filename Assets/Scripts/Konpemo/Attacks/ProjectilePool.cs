using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ProjectilePool : MonoBehaviour
{
    public static ProjectilePool SharedInstance;
    private List<Projectile> pooledObjects;

    [SerializeField]
    private Projectile ballFoudrePrefab;

    [SerializeField]
    private Projectile piqurePrefab;

    [SerializeField]
    private Projectile coupeVentPrefab;

    

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        pooledObjects = new List<Projectile>();
        /*Projectile tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.gameObject.SetActive(false);
            pooledObjects.Add(tmp);
        }*/
    }
    
    public Projectile GetPooledObject(ProjectileType projType)
    {
        for(int i = 0; i < pooledObjects.Count; i++)
        {
            if((!pooledObjects[i].gameObject.activeInHierarchy) && (pooledObjects[i].projType == projType))
            {
                return pooledObjects[i];
            }
        }

        switch(projType)
        {
            case ProjectileType.BallFoudre:
                Projectile newBallFoudre = Instantiate(ballFoudrePrefab);
                pooledObjects.Add(newBallFoudre);
                return newBallFoudre;

            case ProjectileType.Piqure:
                Projectile newPiqure = Instantiate(piqurePrefab);
                pooledObjects.Add(newPiqure);
                return newPiqure;

            case ProjectileType.CoupeVent:
                Projectile newCoupeVent = Instantiate(coupeVentPrefab);
                pooledObjects.Add(newCoupeVent);
                return newCoupeVent;

            default: return null;
        }
        
    }
}
