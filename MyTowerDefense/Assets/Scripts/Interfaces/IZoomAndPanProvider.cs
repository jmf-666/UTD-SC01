using UnityEngine;

internal interface IZoomAndPanProvider 
{
    Vector3 GetPanDirection();
    float GetZoom();

}
