using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;

    void FixedUpdate()
    {
        Vector3 targetPos = target.position + offset;

        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);

        smoothedPosition.z = offset.z;

        transform.position = smoothedPosition;
    }
}
