using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LidarSensor : MonoBehaviour
{
    [SerializeField] private int numRays;
    [SerializeField] private float angle;
    [SerializeField] private float distance;
    [SerializeField] private LineRenderer lineRendererPrefab;

    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = Instantiate(lineRendererPrefab, transform);
        lineRenderer.positionCount = numRays;
    }

    private void FixedUpdate()
    {
        float startAngle = -angle / 2;
        float angleStep = angle / (numRays - 1);

        for (int i = 0; i < numRays; i++)
        {
            float currentAngle = startAngle + i * angleStep;
            Vector3 direction = Quaternion.Euler(0, currentAngle, 0) * transform.forward;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, direction, out hit, distance))
            {
                lineRenderer.SetPosition(i, hit.point);
            }
            else
            {
                lineRenderer.SetPosition(i, transform.position + direction * distance);
            }
        }
    }
}
