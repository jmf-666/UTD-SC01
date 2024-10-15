using UnityEngine;

internal interface ITransposer
{
    void Pan(Vector3 direction);
    void Zoom(float zoomValue);
}
