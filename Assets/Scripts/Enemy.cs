using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] int hp;

    public void GetDamage(int damage) => hp -= damage;
    

    public void GetEffect() => StartCoroutine(DecreaseHealth());
    

    private void Update()
    {
        if (hp<=0)
        {
            Destroy(gameObject);
        }
    }

    

    IEnumerator DecreaseHealth()
    {
        float damageInterval = 1;
        while (hp>0)
        {
            hp--;
            yield return new WaitForSeconds(damageInterval);
        }
        yield return null;
    }

    
}
