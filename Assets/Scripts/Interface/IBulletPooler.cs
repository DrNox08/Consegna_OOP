using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBulletPooler 
{
    (GameObject, IBullet) GetPooledObject();
}
