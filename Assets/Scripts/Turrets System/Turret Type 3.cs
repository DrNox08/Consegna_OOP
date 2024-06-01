using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretType3 : Turret
{
    protected override void Start()
    {
        base.Start();
        shootingRange *= 1.5f;
    }
}
