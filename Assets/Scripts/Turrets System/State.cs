using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    public enum STATE
    {
        INACTIVE, ACTIVE, BUFFED
    }

    public enum EVENT
    {
        ENTER, UPDATE, EXIT
    }

    public STATE state;
    protected EVENT stage;

    float firerate = 1;
    Buff buff = null;

    public State(float fireRate, Buff buff)
    {
        this.firerate = fireRate;
        this.buff = buff;
    }
        

    
}
