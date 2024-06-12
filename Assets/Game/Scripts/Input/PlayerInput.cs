using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public LayerMask diceLayerMask;
    public LayerMask ground;

    public Transform pointer;

    public Vector3 FindMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] raycastHit = Physics.RaycastAll(ray, 10000f, ground);
        if(raycastHit == null)
        {
            Debug.Log("Mouse doesnt collide with ground!");
            return new Vector3(0, 0, 0);
        }
        return raycastHit[0].point;
    }

    public static PlayerInput singleton;
    private void Awake()
    {
        singleton = this;
    }
}
