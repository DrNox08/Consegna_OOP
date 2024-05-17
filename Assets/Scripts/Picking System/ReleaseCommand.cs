using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseCommand : Command
{
    LayerMask pickable;
    public ReleaseCommand(LayerMask pickable)
    {
        this.pickable = pickable;
    }
    public override void Execute(ObjectPicker picker)
    {
        GameObject selectedObj = picker.GetObject();
        if (selectedObj != null)
        {
            
            Ray ray = new (selectedObj.transform.position, Vector3.down);
            Debug.DrawRay(selectedObj.transform.position, Vector3.down, Color.magenta);
            if (Physics.Raycast(ray, out RaycastHit hit, 10f))
            {
                if (hit.collider.CompareTag("DropZone"))
                {
                    Debug.Log("la tag è: " + hit.collider.tag);
                    picker.SetObject(null);
                    picker.ChangeCommand(new PickCommand(pickable));
                }
            }
            
                
                
                    
                
        }
    }
}
