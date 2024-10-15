using UnityEngine;
using UnityEngine.EventSystems;

public class RayCastLayerSelector : MonoBehaviour, ISelector
{
    [SerializeField] private float maxDistance = 100;
    [SerializeField] private LayerMask layerMask;

    private Transform selection;

    public void CheckRay(Ray ray)
    {
        selection = null;
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!Physics.Raycast(ray, out var hit, maxDistance, layerMask )) return;
        selection = hit.transform;

    }

    public Transform GetSelected()
    {
        return selection;
    }
}
