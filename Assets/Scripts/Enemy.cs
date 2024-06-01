using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] int hp;
    [SerializeField] Material redMaterial;
    Renderer objRenderer;
    Material originalMaterial;
    int fullHP;

    Vector3 startPosition;

    private void Awake()
    {
        objRenderer = GetComponent<Renderer>();
    }

    private void Start()
    {
        startPosition = transform.position;
        originalMaterial = objRenderer.material;
    }
        

    public void GetDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
            gameObject.SetActive(false);
    }

    public void GetEffect()
    {
        if( gameObject.activeInHierarchy )
            StartCoroutine(DecreaseHealth());
    }

    IEnumerator DecreaseHealth()
    {
        objRenderer.material = redMaterial;
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
        objRenderer.material = originalMaterial;
        gameObject.layer = 7;
    }

    private void OnDisable()
    {
        hp = fullHP;
        transform.position = startPosition;
    }








}
