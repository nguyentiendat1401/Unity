using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererExample : MonoBehaviour
{
    private LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        // Đặt số điểm của đường cần vẽ
        lineRenderer.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position + Vector3.up * 5f);
    }
}
