using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTesla : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target;
    [SerializeField] private float translateSpeed;
    [SerializeField] private float rotationSpeed;

    private void FixedUpdate()
    {
        HandleTranslation();
        HandleRotation();
    }

    private void HandleTranslation()
    {
        var targetPosition = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, translateSpeed * Time.deltaTime);
    }
    private void HandleRotation()
    {
        var direction = target.position - transform.position;
        var rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    // Move the camera to front of the car
    //private void HandleRotation()
    //{
    //    // Get the car's forward vector
    //    var direction = target.forward;

    //    // Make sure the direction is not zero (to avoid errors)
    //    if (direction != Vector3.zero)
    //    {
    //        // Calculate the rotation to look at the car's forward direction
    //        var rotation = Quaternion.LookRotation(direction, Vector3.up);
    //        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    //    }
    //}
}