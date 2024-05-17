using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    bool isActive;
    [SerializeField] protected float fireRate;
    
    [SerializeField] protected float shootingRange;
    [SerializeField] LayerMask enemy;
    Vector3 enemyPosition;

    float fireTime;

    private void Start()
    {
        isActive = true; // TODO: settare a false per il gioco
        fireTime = 0;
    }

    private void Update()
    {
        if (isActive)
        {
            if(Time.time >= fireTime)
            {
                Shoot();
                fireTime = Time.time + 1f / fireRate;
            }
        }
        
    }

    public virtual void Shoot()
    {
        if(EnemyIsInRange()) 
        {
            transform.LookAt(enemyPosition);
            
            var (bullet, bulletLogic) = ObjectPooler.SharedInstance.GetPooledObject();
            if(bullet != null && bulletLogic != null)
            {
                
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;
                bullet.SetActive(true);
                Vector3 target = (enemyPosition - transform.position);
                bulletLogic.GoToEnemy(target);
            }
        }
    }

    bool EnemyIsInRange()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, shootingRange, enemy);
        if(colliders.Length > 0)    
            enemyPosition = colliders[0].gameObject.transform.position;
        Debug.Log(enemyPosition);
        return colliders.Length > 0;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
