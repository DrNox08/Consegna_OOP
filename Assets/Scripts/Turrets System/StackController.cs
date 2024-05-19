using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackController : MonoBehaviour
{
    
    public List<Turret> turretList;

    private void Start()
    {
        turretList = new List<Turret>();
    }

    
    private void OnTriggerStay(Collider other)
    {
        if(other.TryGetComponent(out Turret turret) && !GameManager.anObjectIsHeld)
        {
            if(!turretList.Contains(turret)) 
                turretList.Add(turret);
            Debug.Log("torrette in stack" +  turretList.Count); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Turret turret))
            turretList.Remove(turret);
        Debug.Log("torrette in stack" + turretList.Count);
    }
}
