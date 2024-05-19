using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Turret : MonoBehaviour
{
    bool isActive;
    
    
    [SerializeField] protected float fireRate;
    
    [SerializeField] protected float shootingRange;
    [SerializeField] LayerMask enemy;
    List<Transform> enemiesInRange;
    Transform currentTarget;
    float fireTime;

    private void Start()
    {
        isActive = true; // TODO: settare a false per il gioco
        fireTime = 0;
        enemiesInRange = new List<Transform>();
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

    public virtual void Shoot()
    {
        if (currentTarget != null)
        {
            var (bullet, bulletLogic) = ObjectPooler.SharedInstance.GetPooledObject();
            if (bullet != null && bulletLogic != null)
            {
                bullet.transform.SetPositionAndRotation(transform.position, transform.rotation);
                bullet.SetActive(true);
                Vector3 targetDirection = (currentTarget.position - transform.position).normalized;
                bulletLogic.GoToEnemy(targetDirection);
            }
        }
    }

    void UpdateEnemiesInRange()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, shootingRange, enemy);
        List<Transform> currentEnemies = new List<Transform>();

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
