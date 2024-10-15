using UnityEngine;

internal interface ISelector
{
    void CheckRay(Ray ray);
    Transform GetSelected();
}