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

    private Vector3 initialObjectPosition;
    private Vector3 initialMousePosition;
    private const float SelectedObjectHeight = 2.5f; // Posizion in y in picking

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
                    SetInitialMouseOffset();
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

    private void SetInitialMouseOffset()
    {
        initialObjectPosition = selectedObj.transform.position;
        initialMousePosition = Input.mousePosition;
    }

    private void MoveObjectWithMouse()
    {
        Vector3 mouseDelta = (Input.mousePosition - initialMousePosition) * 0.01f; // Moltiplicatore movemente del picked obj
        selectedObj.transform.position = new Vector3(initialObjectPosition.x + mouseDelta.x, SelectedObjectHeight, initialObjectPosition.z + mouseDelta.y);
    }

    public void SetObject(GameObject obj)
    {
        selectedObj = obj;
        isDragging = obj != null;
        if (obj != null)
        {
            SetInitialMouseOffset();
        }
    }

    public GameObject GetObject() => selectedObj;
    public void ChangeCommand(Command _command) => command = _command;
}
