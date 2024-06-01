using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavMapManager : MonoBehaviour
{
     Transform targetTransform;

     static Vector3 targetPos;

    private void Awake()
    {
        targetTransform = transform.GetChild(0);
        targetPos = targetTransform.position;
        Debug.Log(targetPos);
    }

    public static Vector3 GetDestination( )
    {
      return targetPos;
    }
}
