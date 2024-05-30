using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBuff : MonoBehaviour, IBuff
{
    public void ApplyBuff(Turret turret)
    {
        turret.currentBulletPooler = turret.fireBulletPool;
    }

    public void RemoveBuff(Turret turret)
    {
        turret.currentBulletPooler = turret.baseBulletPool;
    }
}

