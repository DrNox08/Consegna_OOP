using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickCommand : Command
{
    public override void Execute(ObjectPicker picker)
    {
        if (InputManager.MouseLeft != 0)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit, Mathf.Infinity))
            {
                Debug.Log("colpito");
                if (hit.transform)
                {
                    picker.SetObject(hit.transform.gameObject);
                }
            }
        }
    }
}
