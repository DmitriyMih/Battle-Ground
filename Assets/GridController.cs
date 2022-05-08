using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public Vector2Int gridSizeX;
    public Vector2Int gridSizeY;

    [Header("Base Settings")]
    public Vector2Int basePosition;
    public Transform basePrefab;

    public Transform gridPoint;
    public float scale = 1f;

    public void Awake()
    {

    }

    public Transform groundPrefab;

    public Transform groundGroup;
    public List<Transform> baseGroundList = new List<Transform>();

    private List<GameObject> ground = new List<GameObject>();

    

    [ContextMenu("Initialization Ground")]
    public void InititalizationGround()
    {
        if (gridPoint == null)
            return;

        RemoveGround();

        for (int x = gridSizeX.x; x < gridSizeX.y + 1; x++)
        {
            for (int y = gridSizeY.x; y < gridSizeY.y + 1; y++)
            {
                if ((x + y) % 2 == 0)
                    Gizmos.color = Color.red;
                else
                    Gizmos.color = Color.yellow;

                Vector3 currentPosition = gridPoint.position + new Vector3(x, 0, y) * scale;
                
                GameObject groundItem = Instantiate(groundPrefab.gameObject, currentPosition, Quaternion.identity);
                groundItem.transform.localScale = Vector3.one * scale;
                groundItem.transform.parent = groundGroup;

                GroundItem item = groundItem.GetComponent<GroundItem>();
                if(Random.Range(0, 9) == 4)
                {
                    item.currentType = (GroundItem.GroundType)Random.Range(0, 3);
                    item.Initialization();
                    Debug.Log("Type " + item.currentType);
                }

                ground.Add(groundItem);
            }
        }
    }
    
    [ContextMenu("Remove Ground")]
    public void RemoveGround()
    {
        foreach (var gro in ground)
            DestroyImmediate(gro);

    }

    public void OnDrawGizmosSelected()
    {
        if (gridPoint == null)
            return;

        for (int x = gridSizeX.x; x < gridSizeX.y + 1; x++)
        {
            for (int y = gridSizeY.x; y < gridSizeY.y + 1; y++)
            {
                if ((x + y) % 2 == 0)
                    Gizmos.color = Color.red;
                else
                    Gizmos.color = Color.yellow;

                Vector3 currentPosition = gridPoint.position + new Vector3(x, 0, y) * scale;
                Gizmos.DrawCube(currentPosition, Vector3.one * scale);
            }
        }
     
        if (basePrefab != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawCube(gridPoint.position + new Vector3(basePosition.x, 0, basePosition.y) * scale, Vector3.one * scale);
            basePrefab.position = gridPoint.position + new Vector3(basePosition.x, 0, basePosition.y) * scale;
        }
    }
}
