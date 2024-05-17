using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff 
{
    public enum BUFFTYPE
    {
        FIRE, RATIO
    }

    protected float fireRateMultiplier = 2f;
    protected bool isFireProjectile = false;

    protected BUFFTYPE buffType;

    public virtual void ApplyBuff(BUFFTYPE type)
    {
        if (buffType == BUFFTYPE.FIRE) { isFireProjectile = true; }
        else if (buffType == BUFFTYPE.RATIO) { isFireProjectile = false;  }
    }

    public Buff(float fireRateMultiplier, bool isFireProjectile, BUFFTYPE buffType)
    {
        this.fireRateMultiplier = fireRateMultiplier;
        this.isFireProjectile = isFireProjectile;
        this.buffType = buffType;
    }
}

public class FireBuff : Buff
{

    public FireBuff(float fireRateMultiplier, bool isFireProjectile, BUFFTYPE buffType) : base(fireRateMultiplier, isFireProjectile, buffType)
    {

    }
}


