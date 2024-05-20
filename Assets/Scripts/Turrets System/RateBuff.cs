using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateBuff : MonoBehaviour, IPickable, IBuff
{
    float fireRateMultiplier = 2f;
    
    List<Turret> buffedTurrets;

    private void Start()
    {
        buffedTurrets = new List<Turret>();
    }



    public void ApplyBuff(Turret turret)
    {
        if (!buffedTurrets.Contains(turret))
        {
            turret.fireRate *= fireRateMultiplier;
            buffedTurrets.Add(turret);
        }
    }
        
            

    public void RemoveBuff(Turret turret)
    {
        if(buffedTurrets.Contains(turret))
        {
            turret.fireRate /= fireRateMultiplier;
            buffedTurrets.Remove(turret);
        }
    }

        
}




