using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapAimer : MonoBehaviour, IAimer
{
    [SerializeField] LayerMask layerMask;
    float range;
    [SerializeField] Collider[] colliders;

    public void SetRange(float unitRange)
    {
        range = unitRange;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void GetElements()
    {
        Physics.OverlapSphereNonAlloc(transform.position, range, colliders, layerMask);
    }

    public Transform GetNearest()
    {
        float shortestDistance = Mathf.Infinity;
        GameObject nearestElement = null;
        foreach (Collider collider in colliders)
        {
            if (collider != null)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, collider.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestElement = collider.gameObject;
                }
            }
        }

        if (nearestElement != null && shortestDistance <= range)
        {
            return nearestElement.transform;
        }
        else
        {
            return null;
        }
    }
}
