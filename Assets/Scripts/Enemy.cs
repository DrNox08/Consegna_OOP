using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] int hp;
    int fullHP;

    Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }
        

    public void GetDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
            gameObject.SetActive(false);
    }
        
    public void GetEffect() => StartCoroutine(DecreaseHealth());

    

    IEnumerator DecreaseHealth()
    {
        float damageInterval = 1;
        while (hp>0)
        {
            hp--;
            yield return new WaitForSeconds(damageInterval);
        }
        yield return null;
        gameObject.SetActive(false);
        
    }

    private void OnEnable()
    {
        fullHP = hp;
        gameObject.layer = 7;
    }

    private void OnDisable()
    {
        hp = fullHP;
        transform.position = startPosition;
    }








}
