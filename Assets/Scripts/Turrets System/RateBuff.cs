using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateBuff : MonoBehaviour, IPickable
{
    float fireRateMultiplier = 2f;

    public void ApplyRateBuff(List<Turret> turretsOnStack)
    {
        foreach (Turret turret in turretsOnStack)
        {
            turret.fireRate*=fireRateMultiplier;
        }
    }
}




