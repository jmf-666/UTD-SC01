using UnityEngine;

public class MouseScreenRayProvider : MonoBehaviour, IRayProvider
{
    public Ray RayCast()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }
}