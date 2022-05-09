using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGridController : MonoBehaviour
{
    public static GlobalGridController globalGridController;
    public List<GridController> grids = new List<GridController>();
    public float scale = 1.5f;

    [Header("Grid Settings")]
    public Vector2Int gridSizeX;
    public Vector2Int gridSizeY;
    public Transform gridPoint;

    public void Awake()
    {
        globalGridController = this;    
    }

    [ContextMenu("Inititalization Grid")]
    public void InititalizationGrid()
    {
        gridSizeX = grids[0].gridSizeX;
        int lenghtX = 0;
        int lenghtY = 0;

        if (grids.Count % 2 == 0)
        {
            int number = grids.Count / 2;
            Debug.Log("Grid num " + number);
            for (int i = 0; i < number; i++)
            {
                lenghtX += 1;
                lenghtX += (grids[i].gridSizeY.x * -1) + grids[i].gridSizeY.y;
                Debug.Log("Grid num + " + i + " | x = " + (grids[i].gridSizeY.x * -1) + " | y =" + grids[i].gridSizeY.y);
            }
            for (int i = number; i < grids.Count; i++)
            {
                lenghtY += 1;
                lenghtY += (grids[i].gridSizeY.x * -1) + grids[i].gridSizeY.y; 
                Debug.Log("Grid num + " + i + " | x = " + (grids[i].gridSizeY.x * -1) + " | y =" + grids[i].gridSizeY.y);
            }
        }
        else
        {
            int number = grids.Count / 2 + 1;
            lenghtX += (grids[number].gridSizeY.x * -1);
            lenghtY += grids[number].gridSizeY.y;

            Debug.Log(number);
            for (int i = 0; i <  number - 1; i++)
            {
                lenghtX += 1;
                lenghtX += (grids[i].gridSizeY.x * -1) + grids[i].gridSizeY.y;
                Debug.Log("Grid num + " + i + " | x = " + (grids[i].gridSizeY.x * -1) + " | y =" + grids[i].gridSizeY.y);
            }
            for (int i = number; i < grids.Count; i++)
            {
                lenghtY += 1;
                lenghtY += (grids[i].gridSizeY.x * -1) + grids[i].gridSizeY.y;
                Debug.Log("Grid num + " + i + " | " + lenghtY);
            }
        }
        gridSizeY = new Vector2Int(-lenghtX, lenghtY);


        //gridSizeY = new Vector2Int(-lenghtY / 2, lenghtY / 2);

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
                    Gizmos.color = Color.white;
                else
                    Gizmos.color = Color.black;

                Vector3 currentPosition = gridPoint.position + new Vector3(x, 0, y) * scale;
                Gizmos.DrawCube(currentPosition, Vector3.one * scale);
            }
        }

    }
}
