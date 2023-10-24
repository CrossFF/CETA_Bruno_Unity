using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldNumber : MonoBehaviour
{
    private LineRenderer lineRenderer;

    public Color lineColor;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update() {
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;
    }

    public void SetPosition(Vector3 pos)
    {
        transform.position = pos;
        Vector3 topPoint = new Vector3(transform.position.x, 
                                       transform.position.y + 20f, 
                                       transform.position.z);
        Vector3[] positions = new Vector3[2];
        positions[0] = transform.position;
        positions[1] = topPoint;
        lineRenderer.SetPositions(positions);
    }
}
