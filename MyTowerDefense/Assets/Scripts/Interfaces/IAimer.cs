
using UnityEngine;

internal interface IAimer 
{
    void SetRange(float range);
    void GetElements();
    Transform GetNearest();
}
