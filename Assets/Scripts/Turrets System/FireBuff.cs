using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBuff : MonoBehaviour, IBuff
{
    public void ApplyBuff(Turret turret)
    {
        turret.currentPooler = FireBulletPooler.SharedInstance;
    }

    public void RemoveBuff(Turret turret)
    {
        turret.currentPooler = BaseBulletPooler.SharedInstance;
    }
}

