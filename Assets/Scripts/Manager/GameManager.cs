using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool anObjectIsHeld;

    private void Awake()
    {
        Time.timeScale = 1.0f;
    }

    private void Start()
    {
        anObjectIsHeld = false;
        
    }
}
