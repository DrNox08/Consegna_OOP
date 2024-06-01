
using System.Collections.Generic;
using UnityEngine;


public class Turret : MonoBehaviour, IPickable, ITurret
{
    [SerializeField] protected bool isActive;


    
    [SerializeField] protected float fireRate;
    [SerializeField] protected float shootingRange = 4.5f;
    [SerializeField] protected LayerMask enemy;
    [SerializeField] protected float shootDelay = 2;
    List<Transform> enemiesInRange;
    protected Transform currentTarget;
    protected float fireTime;

    //poolers
    public IBulletPooler currentPooler;

    public float FireRate { get => fireRate; set => fireRate = value; }
    public bool IsActive { get => isActive; set => isActive = value; }
    public IBulletPooler CurrentPooler { get => currentPooler; set => currentPooler = value; }

    protected virtual void Start()
    {
        shootDelay = 2;
        shootingRange = 4.5f;
        fireRate = 2;
        isActive = false;
        fireTime = 0;
        enemiesInRange = new List<Transform>();
        //poolers

        currentPooler = BaseBulletPooler.SharedInstance;
    }

    protected virtual void FixedUpdate()
    {
        if (isActive)
        {
            if (Time.time >= fireTime)
            {
                Shoot();
                fireTime = Time.time + shootDelay / fireRate;
            }

            UpdateEnemiesInRange();
            UpdateTarget();
        }
    }

    public void Shoot()
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
                    
            
               

    protected void UpdateEnemiesInRange()
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
        
        

   protected void UpdateTarget() // decide quale enemy andare a prendere
    {
        if (currentTarget == null && enemiesInRange.Count > 0)
        {
            currentTarget = enemiesInRange[0]; // se c'è più di un enemy prende il primo e si gode
        }

        if (currentTarget != null && !EnemyIsInRange(currentTarget)) 
        {
            enemiesInRange.Remove(currentTarget); // se l'enemy è uscito dal range, target è null e ricomincia
            currentTarget = null;
        }
    }
        
    protected bool EnemyIsInRange(Transform target)
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

