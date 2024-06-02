using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamageable
{

    //event
    public static Action OnStartingWave;
    [SerializeField] int hp;
    [SerializeField] Material redMaterial;
    Renderer objRenderer;
    Material originalMaterial;
    NavMeshAgent agent;
    int fullHP;

    Vector3 startPosition;

    private void Awake()
    {
        objRenderer = GetComponent<Renderer>();
        agent = GetComponent<NavMeshAgent>();
        OnStartingWave += SelfEnable;
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Base"))
        {
            gameObject.SetActive(false);
            Base.OnEnemyAttack?.Invoke();
        }
    }
        

    void SelfEnable()
    {
        gameObject.SetActive(true);
    }
        

    private void OnEnable()
    {
        fullHP = hp;
        objRenderer.material = originalMaterial;
        gameObject.layer = 7;
        agent.SetDestination(NavMapManager.GetDestination());
    }

    private void OnDisable()
    {
        hp = fullHP;
        transform.position = startPosition;
    }

    private void OnDestroy()
    {
        OnStartingWave -= SelfEnable;
    }








}
