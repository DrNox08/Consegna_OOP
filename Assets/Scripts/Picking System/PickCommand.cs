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
                if (hit.transform.TryGetComponent(out ITurret turret)) { turret.IsActive = false; }

                // Aggiorna solo la coordinata Y
                GameObject selectedObj = hit.transform.gameObject;
                Vector3 currentPosition = selectedObj.transform.position;

                // Calcola la nuova posizione Y basata sulla posizione del mouse
                Plane groundPlane = new(Vector3.up, Vector3.zero);
                if (groundPlane.Raycast(ray, out float distance))
                {
                    Vector3 mousePosition = ray.GetPoint(distance);
                    selectedObj.transform.position = new Vector3(currentPosition.x, mousePosition.y, currentPosition.z);
                }
            }
        }
        else
        {
            picker.SetObject(null);
        }
    }
}
