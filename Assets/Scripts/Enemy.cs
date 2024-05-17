using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] int hp;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            hp--;
        }
    }

    private void Update()
    {
        if (hp<=0)
        {
            Destroy(gameObject);
        }
    }
}
