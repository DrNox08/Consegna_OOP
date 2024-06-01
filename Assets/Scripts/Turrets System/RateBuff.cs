using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateBuff : MonoBehaviour, IPickable, IBuff
{
    readonly float fireRateMultiplier = 1f;
    
    List<ITurret> buffedTurrets;

    private void Start()
    {
        buffedTurrets = new List<ITurret>();
    }



    public void ApplyBuff(ITurret turret)
    {
        if (!buffedTurrets.Contains(turret))
        {
            turret.FireRate += fireRateMultiplier;
            buffedTurrets.Add(turret);
        }
    }
        
            

    public void RemoveBuff(ITurret turret)
    {
        if(buffedTurrets.Contains(turret))
        {
            turret.FireRate -= fireRateMultiplier;
            buffedTurrets.Remove(turret);
        }
    }

        
}




