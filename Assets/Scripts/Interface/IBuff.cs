using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuff 
{
    public void ApplyBuff(Turret turret);

    public void RemoveBuff(Turret turret);
}
