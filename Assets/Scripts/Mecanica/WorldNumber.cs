using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldNumber : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public Color lineColor;
    public int numberValue; // valor que representa el objeto;
    public bool vertical = false;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;
    }

    public void SetPosition(Vector3 pos)
    {
        transform.position = pos;
        Vector3 topPoint;
        BoxCollider2D col = GetComponent<BoxCollider2D>();
        if (!vertical)
        {
            topPoint = new Vector3(transform.position.x,
                                   transform.position.y + 4f,
                                   transform.position.z);
            // collider
            col.offset = new Vector2(0f,1f);
            col.size = new Vector2(0.1f, 2f);
        }
        else
        {
            topPoint = new Vector3(transform.position.x - 4f,
                                   transform.position.y,
                                   transform.position.z);
            // collider
            col.offset = new Vector2(-3f,0f);
            col.size = new Vector2(2f, 0.1f);
        }
        Vector3[] positions = new Vector3[2];
        positions[0] = transform.position;
        positions[1] = topPoint;
        lineRenderer.SetPositions(positions);
    }
}
