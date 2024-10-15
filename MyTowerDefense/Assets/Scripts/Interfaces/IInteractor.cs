using System;
using UnityEngine;

internal interface IInteractor
{
    void GetInteractInput();
    event Action OnInteractEvent;
}
