using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : Bullet, IBullet
{
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out IDamageable damageable))
        {
            damageable.GetDamage(base.damage);
            damageable.GetEffect();
            gameObject.SetActive(false);
        }
    }
}
