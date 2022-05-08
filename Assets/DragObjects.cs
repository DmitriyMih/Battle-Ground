using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DragObjects : MonoBehaviour
{
    [Header("Main Settings")]
    [SerializeField] private Camera mainCamera;

    public bool isActive = false;

    [Header("Positions Settings")]
    private float clampPositionY = 0.5f;
    public Vector3 nextPosition;

    [Header("Debug Settings")]
    [SerializeField] private float debugRadius = 1f;

    [Header("Line Settings")]
    public LineRenderer lineRenderer;
    //private List<Transform> linePoint = new List<Transform>();

    [Header("AI Settings")]
    public NavMeshAgent agent;
    
    public void Awake()
    {
        mainCamera = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        if (isActive)
            return;

        if(nextPosition!= transform.position && nextPosition != null)
            agent.SetDestination(nextPosition);
        
        //var groundPlane = new Plane(Vector3.up, Vector3.zero);
        //Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        //if (groundPlane.Raycast(ray, out float position))
        //{
        //    Vector3 worldPosition = ray.GetPoint(position);
        //    nextPosition = worldPosition;

        //    Vector3 newPosition = new Vector3(worldPosition.x, clampPositionY, worldPosition.z);
        //    transform.position = newPosition; ;
        //}

        if (nextPosition.x == transform.position.x && nextPosition.z == transform.position.z)
        {
            isActive = true;
            nextPosition = transform.position;
            Debug.Log("Exit In Update = " + isActive);
        }
    }

    public void OnMouseDown()
    {
        Debug.Log("Down");
    }

    public void OnMouseDrag()
    {
        var groundPlane = new Plane(Vector3.up, Vector3.zero);
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (groundPlane.Raycast(ray, out float position))
        {
            Vector3 newPosition = ray.GetPoint(position);
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, newPosition);
        }
    }

    private void OnMouseUp()
    {
        var groundPlane = new Plane(Vector3.up, Vector3.zero);
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (groundPlane.Raycast(ray, out float position))
        {
            Vector3 newPosition = ray.GetPoint(position);
            if (newPosition.x == transform.position.x && newPosition.z == transform.position.z)
            {
                isActive = true;
                Debug.Log("Exit = " + isActive);
            }
            else
            {
                isActive = false;
                nextPosition = newPosition;
            }
        }

        lineRenderer.SetPosition(0, Vector3.zero);
        lineRenderer.SetPosition(1, Vector3.zero);
        //isActive = false;
            Debug.Log("Drop");
    }

    public void OnDrawGizmos()
    {
        //  debug transform
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, debugRadius);

        //  debug draw line
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, nextPosition);

        //  debug next position
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(nextPosition, debugRadius);

    }
}
