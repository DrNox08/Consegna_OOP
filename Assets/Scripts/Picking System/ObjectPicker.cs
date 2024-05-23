using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectPicker : MonoBehaviour
{
    private Command command;
    private GameObject selectedObj;
    public bool isDragging;
    private bool isSelected;
    [SerializeField] protected LayerMask pickable;

    private void Awake() => command = new PickCommand(pickable);
    private void Update()
    {
        GameManager.anObjectIsHeld = selectedObj != null;
        
        if (InputManager.MouseLeft)
        {
            if (!isSelected)
            {
                command.Execute(this);
                
                if (selectedObj != null)
                {
                    isSelected = true;
                    isDragging = true;
                }
            }
            else
            {
                
                command = new ReleaseCommand(pickable);
                command.Execute(this);

                if (selectedObj == null)
                {
                    isSelected = false;
                    isDragging = false;
                    command = new PickCommand(pickable);
                }
            }
                
        }
                
        if (isDragging && selectedObj != null)
        {
            MoveObjectWithMouse();
        }
    }

        

    private void MoveObjectWithMouse()
    {
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new (Vector3.up, Vector3.up * 2.5f); // altezza in y dell'oggeto in picking
        if (groundPlane.Raycast(ray, out float enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            selectedObj.transform.position = hitPoint;
        }
    }

    public void SetObject(GameObject obj)
    {
        selectedObj = obj;
        isDragging = obj != null;
    }

    public GameObject GetObject() => selectedObj;
    public void ChangeCommand(Command _command) => command = _command;
}
