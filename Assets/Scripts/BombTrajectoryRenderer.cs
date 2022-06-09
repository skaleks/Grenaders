using UnityEngine;

public class BombTrajectoryRenderer : MonoBehaviour
{
    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void Render (Vector3 direction)
    {

        Vector3[] points = new Vector3[10];
        lineRenderer.positionCount = points.Length;

        for(int i = 0; i < points.Length; i++)
        {
            float time = i * 0.1f;

            points[i] = transform.position + direction * time + Physics.gravity * time * time / 2f;
        }

        lineRenderer.SetPositions(points);
    }

    public void ClearLine()
    {
        lineRenderer.positionCount = 0;
    }
}
