using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickCommand : Command
{
    LayerMask pickableLayer;
    public PickCommand(LayerMask pickable)
    {
        pickableLayer = pickable;
    }
    public override void Execute(ObjectPicker picker)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, pickableLayer))
        {
            if (hit.transform)
            {
                picker.SetObject(hit.transform.gameObject);
                if(hit.transform.TryGetComponent(out Turret turret) ) { turret.isActive = false; }
            }
        }
        else
        {
            picker.SetObject(null);
        }
    }
}
