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
            Debug.DrawRay(selectedObj.transform.position, Vector3.down * 20, Color.magenta, 5);
            if (Physics.Raycast(ray, out RaycastHit hit, 20f))
            {
                
                if (hit.collider.CompareTag("DropZone") || hit.collider.transform.TryGetComponent<IPickable>(out _))
                {
                    
                    float yTarget = hit.transform.position.y + hit.transform.localScale.y / 2 + selectedObj.transform.localScale.y/2;
                    
                    Vector3 targetPosition = new(hit.transform.position.x, yTarget, hit.transform.position.z);
                    selectedObj.transform.position = targetPosition;
                    picker.SetObject(null);
                    picker.ChangeCommand(new PickCommand(pickable));
                }
            }
                    
            
                
                
                    
                
        }
    }
}
