using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackController : MonoBehaviour
{
    
    public List<ITurret> turretList;
    
    List<IBuff> buffsList;

    private void Start()
    {
        turretList = new List<ITurret>();
        
        buffsList = new List<IBuff>();
    }

    
    private void OnTriggerStay(Collider other)
    {
        if (GameManager.anObjectIsHeld) return;
        if (other.TryGetComponent(out ITurret turret))
        {
            turret.IsActive = true;
            foreach (IBuff buff in buffsList)
            {
                turretList.Add(turret);
                buff.ApplyBuff(turret);
            }
        }
        else if (other.TryGetComponent(out IBuff buff) && !buffsList.Contains(buff))
        {
            buffsList.Add(buff);
            foreach (ITurret t in turretList)
            {
                buff.ApplyBuff(t);
            }
        }
    }
                
                
                    
                

            
         
         
            

    private void OnTriggerExit(Collider other)
    {
        if (!GameManager.anObjectIsHeld) return;
        if(other.TryGetComponent(out ITurret turret))
        {
            foreach(IBuff buff in buffsList)
            {
                turretList.Remove(turret);
                buff.RemoveBuff(turret);
            }
                
        }
        else if (other.TryGetComponent(out IBuff buff))
        {
            buffsList.Remove(buff);
            foreach(ITurret turretToNerf in turretList)
                buff.RemoveBuff(turretToNerf);
        }
            
    }

}
