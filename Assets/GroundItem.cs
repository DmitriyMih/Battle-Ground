using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundItem : MonoBehaviour
{
    public List<GameObject> objectPrefab = new List<GameObject>();

    public GroundType currentType;
    public enum GroundType
    {
        non,
        sandbags,
        trench,
        hedgehog
    }

    [ContextMenu("Inititalization Ground")]
    public void Initialization()
    {
        foreach (var obj in objectPrefab)
            obj.SetActive(false);

        switch(currentType)
        {
            case GroundType.non:
                objectPrefab[0].SetActive(true);        
                break;

            case GroundType.sandbags:
                objectPrefab[1].SetActive(true);
                break;

            case GroundType.trench:
                objectPrefab[2].SetActive(true);
                break;

            case GroundType.hedgehog:
                objectPrefab[3].SetActive(true);
                break;
        }
    }
}
