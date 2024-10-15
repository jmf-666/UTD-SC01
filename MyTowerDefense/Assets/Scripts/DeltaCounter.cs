using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeltaCounter : MonoBehaviour, ICounter
{

    private float countdown;

    public float GetCounter()
    {
        return countdown;
    }

    public bool Count()
    {
        if (countdown <= 0f)
        {
            return true;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        return false;
    }
    public void SetCounter(float time)
    {
        countdown = time;
    }

}
