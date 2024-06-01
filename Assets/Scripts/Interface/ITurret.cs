using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITurret
{
   public float FireRate {  get; set; }
   public bool IsActive { get; set; }
   public IBulletPooler CurrentPooler { get; set; }

}
