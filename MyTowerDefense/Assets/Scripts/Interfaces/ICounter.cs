using UnityEngine;

internal interface ICounter 
{
    void SetCounter(float time);
    bool Count();
    float GetCounter();
}
