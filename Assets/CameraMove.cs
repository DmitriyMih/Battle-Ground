using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform cameraTransform;
    public int pointCount;

    public float speed = 2.5f;
    public float currentDistance;
    public Vector2Int clampPositions;

    public void Awake()
    {
        currentDistance = cameraTransform.position.z;    
    }

    public void Update()
    {
        float horizontal = Input.GetAxis("Vertical");

        currentDistance = Mathf.Clamp(currentDistance + horizontal * 2.5f, clampPositions.x, clampPositions.y);
        cameraTransform.position = new Vector3(cameraTransform.position.x, cameraTransform.position.y, currentDistance);
    }
}
