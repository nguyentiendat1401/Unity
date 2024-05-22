using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLineOnClick : MonoBehaviour
{
    private LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 10;

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            AddPoint(worldPos);
        }
    }

    void AddPoint(Vector3 point)
    {
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, point);
    }
}
