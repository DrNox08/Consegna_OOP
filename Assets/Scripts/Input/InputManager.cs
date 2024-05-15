using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public static class InputManager
{
    public static ActionMap actionMap;

     static InputManager()
     { 
        actionMap = new ActionMap();
        actionMap.Enable();
     }

    public static bool MouseLeft => actionMap.Player.Pressing.WasPerformedThisFrame();


    //public static bool IsPressing(out float button)
    //{
    //    button = MouseLeft;
    //    return button != 0;
    //}
        
}
