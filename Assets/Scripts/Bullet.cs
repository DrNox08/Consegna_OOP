using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    public Rigidbody rb;
    public Vector3 target;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rb.velocity = target * speed * Time.deltaTime;  
    }

    public void GoToEnemy(Vector3 direction)
    {
        rb.AddRelativeForce(transform.forward * speed, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.TryGetComponent<IDamageable>(out _))
        {
            gameObject.SetActive(false);
        }
    }
}
