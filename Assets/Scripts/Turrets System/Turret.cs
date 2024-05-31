
using System.Collections.Generic;
using UnityEngine;


public class Turret : MonoBehaviour, IPickable
{
    public bool isActive;


    public float baseFireRate;
    public float fireRate;
    [SerializeField] protected float shootingRange;
    [SerializeField] protected LayerMask enemy;
    List<Transform> enemiesInRange;
    protected Transform currentTarget;
    protected float fireTime;

    //poolers
    public IBulletPooler currentPooler;

    private void Start()
    {
        baseFireRate = fireRate;
        isActive = false;
        fireTime = 0;
        enemiesInRange = new List<Transform>();
        //poolers

        currentPooler = BaseBulletPooler.SharedInstance;
    }

    private void FixedUpdate()
    {
        if (isActive)
        {
            if (Time.time >= fireTime)
            {
                Shoot();
                fireTime = Time.time + 1f / fireRate;
            }

            UpdateEnemiesInRange();
            UpdateTarget();
        }
    }

    public  void Shoot()
    {
            if (currentTarget != null)
            {
                var ( bullet, bulletLogic ) = currentPooler.GetPooledObject();
                if (bullet != null && bulletLogic != null)
                {
                    bullet.transform.position = transform.position;
                    bullet.SetActive(true);
                    bulletLogic.SetTarget(currentTarget);
                }
                    
            }
            
               
    }

    void UpdateEnemiesInRange()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, shootingRange, enemy);
        List<Transform> currentEnemies = new();

        foreach (var collider in colliders)
        {
            Transform enemyTransform = collider.transform;
            currentEnemies.Add(enemyTransform);

            if (!enemiesInRange.Contains(enemyTransform))
            {
                enemiesInRange.Add(enemyTransform);
            }
        }

        enemiesInRange.RemoveAll(enemy => !currentEnemies.Contains(enemy));
    }
        
        

    void UpdateTarget()
    {
        if (currentTarget == null && enemiesInRange.Count > 0)
        {
            currentTarget = enemiesInRange[0];
        }

        if (currentTarget != null && !EnemyIsInRange(currentTarget))
        {
            enemiesInRange.Remove(currentTarget);
            currentTarget = null;
        }
    }
        
    bool EnemyIsInRange(Transform target)
    {
        if (target == null)
            return false;

        return Vector3.Distance(transform.position, target.position) <= shootingRange;
    }
        









    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}

