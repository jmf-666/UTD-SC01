using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateTransposer : MonoBehaviour , ITransposer
{

    [SerializeField] private float panSpeed = 30f;
    [SerializeField] private float scrollSpeed = 5f;
    [SerializeField] private float clampMinY = 10f;
    [SerializeField] private float clampMaxY = 80f;

    public void Pan(Vector3 direction)
    {
        transform.Translate(direction * panSpeed * Time.deltaTime, Space.World);
    }

    public void Zoom(float zoomValue)
    {
        Vector3 pos = transform.position;

        pos.y -= zoomValue * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, clampMinY, clampMaxY);

        transform.position = pos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
