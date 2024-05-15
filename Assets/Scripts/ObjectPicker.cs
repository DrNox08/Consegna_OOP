using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectPicker : MonoBehaviour
{
    private Command command;
    private GameObject selectedObj;
    private bool isDragging = false;
    [SerializeField] protected LayerMask pickable;

    private void Awake() => command = new PickCommand();
    private void Update()
    {
        if (InputManager.MouseLeft != 0)
        {
            command.Execute(this);
        }

        if (isDragging && selectedObj != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.up * 3); // y a 3
            if (groundPlane.Raycast(ray, out float enter))
            {
                Vector3 hitPoint = ray.GetPoint(enter);
                selectedObj.transform.position = hitPoint;
            }
        }

        if (InputManager.MouseLeft == 0 && isDragging)
        {
            isDragging = false;
            command = new ReleaseCommand();
            command.Execute(this);
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
