using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshSeeker : MonoBehaviour, ISeeker
{
    private NavMeshAgent agent;
    public event Action OnDestinyEvent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (agent.remainingDistance < 0.1f)
            OnDestinyEvent?.Invoke();
    }
    public Transform GetTarget()
    {                                  
        return GameManager.instance.LevelTarget;
    }

    public void Seek(Transform target)
    {
        agent.SetDestination(target.position); 
    }

    public void SetSeekSpeed(float speed)
    {
        agent.speed = speed;
    }
}
