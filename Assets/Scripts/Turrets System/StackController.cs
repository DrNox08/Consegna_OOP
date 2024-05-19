using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackController : MonoBehaviour
{
    
    public List<Turret> turretList;
    List<Turret> buffedTurrets;
    List<IBuff> buffsList;

    private void Start()
    {
        turretList = new List<Turret>();
        buffedTurrets = new List<Turret>();
        buffsList = new List<IBuff>();
    }

    
    private void OnTriggerStay(Collider other)
    {
        if (GameManager.anObjectIsHeld) return;
         if(other.TryGetComponent(out Turret turret))
            turretList.Add(turret);
         else if(other.TryGetComponent(out IBuff buff) && !buffsList.Contains(buff))
         {
            buffsList.Add(buff);
            foreach(Turret t in turretList)
            {
                
                
                    
                    buff.ApplyBuff(t);
                

            }
            
         }
         
         
    }
            

    private void OnTriggerExit(Collider other)
    {
        if (!GameManager.anObjectIsHeld) return;
        if(other.TryGetComponent(out Turret turret))
        {
            foreach(IBuff buff in buffsList)
            {
                
                turretList.Remove(turret);
                buff.RemoveBuff(turret);
            }
        }
        else if (other.TryGetComponent(out IBuff buff))
        {
            
            foreach(Turret turretToNerf in turretList)
                buff.RemoveBuff(turretToNerf);
        }
            
    }

}
