using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    public Rigidbody rb;
    [SerializeField] int damage;
    Transform enemyTarget;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        damage = 1;
    }

    public void SetTarget(Transform target) => enemyTarget = target;
    

    public void GoToEnemy(Vector3 direction)
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 direction = (enemyTarget.position - rb.position).normalized;
        rb.velocity = direction * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.TryGetComponent(out IDamageable damageable))
        {
            damageable.GetDamage(damage);
            gameObject.SetActive(false);
        }
    }

    private void OnBecameInvisible()
    {
        Debug.Log("è invisibile");
        gameObject.SetActive(false);
    }
}
