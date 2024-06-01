using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBuff : MonoBehaviour, IBuff
{
    public void ApplyBuff(ITurret turret)
    {
        turret.CurrentPooler = FireBulletPooler.SharedInstance;
    }

    public void RemoveBuff(ITurret turret)
    {
        turret.CurrentPooler = BaseBulletPooler.SharedInstance;
    }
}

