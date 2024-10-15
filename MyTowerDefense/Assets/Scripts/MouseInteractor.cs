using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInteractor : MonoBehaviour, IInteractor
{
    public event Action OnInteractEvent;

    public void GetInteractInput()
    {
        if (!BuildManager.instance.CanBuild)
            return;
        if(Input.GetMouseButtonDown(0))
        {
            OnInteractEvent?.Invoke();
        }
        
    }

}
