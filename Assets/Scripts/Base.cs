using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public static Action OnEnemyAttack;

    [SerializeField] int hp = 20;

    private void OnEnable()
    {
        OnEnemyAttack += GetDamage;
    }
    private void OnDisable()
    {
        OnEnemyAttack -= GetDamage;
    }
    public void GetDamage()
    {
        hp--;
        if (hp <= 0) UIManager.OnGameOver?.Invoke();
    }
}
