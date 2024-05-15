using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectPicker : MonoBehaviour
{
    Vector3 mousePos;
    [SerializeField] MovableObject pickedObj;

    private void Start()
    {
    }

    private void Update()
    {
        
        mousePos = Input.mousePosition;
        if (InputManager.MouseLeft)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
        
            if (Physics.Raycast(ray, out hit, Mathf.Infinity) )
            {
                if (hit.transform.TryGetComponent<MovableObject>(out MovableObject obj))
                {
                    pickedObj = obj;
                }

            }

        }
        if (pickedObj != null) { pickedObj.Move(pickedObj.transform.position + (Vector3)Mouse.current.delta.value); }
    }
}
