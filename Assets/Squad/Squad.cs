using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squad : MonoBehaviour
{
    public SquadItem predab;

    public SquadType currentSquadType;
    public enum SquadType
    {
        solider,
        sniper,
        tank
    }

    [Header("Positions Settings")]
    public Transform middlePoint;
    public List<Transform> solidersPositions = new List<Transform>();
    public List<Transform> snipersPositions = new List<Transform>();

    [Header("View Settings")]
    public bool inIspector = true;
    public List<SquadItem> viewObjects = new List<SquadItem>();

    public void Start()
    {
        inIspector = false;
        SquadInitialization();
    }

    [ContextMenu("Inititalization")]
    public void SquadInitialization()
    {
        foreach (var obj in viewObjects)
        {
            if (obj != null)
            {
                if (inIspector == false)
                    Destroy(obj.gameObject);
                else
                    DestroyImmediate(obj.gameObject);
            }
        }
        viewObjects.Clear();

        switch (currentSquadType)
        {
            case SquadType.solider:
                foreach (Transform point in solidersPositions)
                {
                    SquadItem newSoliderObject = Instantiate(predab, point);
                    newSoliderObject.Initialization(SquadType.sniper, point);
                    viewObjects.Add(newSoliderObject);
                }
                break;

            case SquadType.sniper:
                foreach(Transform point in snipersPositions)
                {
                    SquadItem newSniperObject = Instantiate(predab, point);
                    newSniperObject.Initialization(SquadType.sniper, point);
                    viewObjects.Add(newSniperObject);
                }
                break;

            case SquadType.tank:
                SquadItem newTankObject = Instantiate(predab, middlePoint);
                newTankObject.Initialization(SquadType.tank, middlePoint);
                viewObjects.Add(newTankObject);
                break;
        }
    }

}
