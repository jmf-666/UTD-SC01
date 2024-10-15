using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseKeyboardZoomAndPan : MonoBehaviour , IZoomAndPanProvider
{
    
    [SerializeField] private float panBorderThickness = 10f;

    private Vector3 panDirection = Vector3.zero;
    private Vector3 keyboardVector = Vector3.zero;
    private Vector3 mouseVector = Vector3.zero;
    private float zoomY = 0;

    public Vector3 GetPanDirection()
    {
        Vector3 keyboardVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 mouseVector = Vector3.zero;
        if ( Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            mouseVector =Vector3.forward;
        }
        if (Input.mousePosition.y <= panBorderThickness)
        {
            mouseVector = Vector3.back;
        }
        if (Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            mouseVector = Vector3.right;
        }
        if (Input.mousePosition.x <= panBorderThickness)
        {
            mouseVector = Vector3.left;
        }

        return panDirection = (keyboardVector + mouseVector).normalized;
    }

    public float GetZoom()
    {
        zoomY = Input.GetAxis("Mouse ScrollWheel");
        return zoomY;
    }
}
