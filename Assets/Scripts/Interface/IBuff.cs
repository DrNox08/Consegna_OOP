using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuff 
{
    public void ApplyBuff(ITurret turret);

    public void RemoveBuff(ITurret turret);
}
