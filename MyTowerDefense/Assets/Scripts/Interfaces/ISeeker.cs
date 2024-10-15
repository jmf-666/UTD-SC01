
using System;
using UnityEngine;

internal interface ISeeker
{
    Transform GetTarget();
    void Seek(Transform target);
    void SetSeekSpeed(float speed);
    event Action OnDestinyEvent;
}
