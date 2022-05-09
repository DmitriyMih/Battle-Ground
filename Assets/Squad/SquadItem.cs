using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

[Serializable]
public class SquadItem : MonoBehaviour
{
    [Header("Inititalization")]
    [SerializeField] private int initNumber = 0;

    [Space(10)][Header("Data")]
    public List<GameObject> objectsPrefab = new List<GameObject>();

    public List<SquadItemData> squadData = new List<SquadItemData>();

    [Header("Main Settings")]
    public Transform currentPoint;

    public float health = 0;
    public float armor = 0;
    public float speed = 0;
    public float damage = 0;
    public float reload = 0;

    [ContextMenu("Inititalization Prefab")]
    public void InitializationButton()
    {
        Initialization((Squad.SquadType)initNumber, null);
    }

    public void Initialization(Squad.SquadType newType, Transform newPoint)
    {
        foreach (var pref in objectsPrefab)
            pref.SetActive(false);

        switch (newType)
        {
            case Squad.SquadType.solider:
                objectsPrefab[0].SetActive(true);
                
                InitializationData(squadData[0]);
                break;

            case Squad.SquadType.sniper:
                objectsPrefab[1].SetActive(true);
               
                InitializationData(squadData[1]);
                break;

            case Squad.SquadType.tank:
                objectsPrefab[2].SetActive(true);
               
                InitializationData(squadData[2]);
                break;
        }

        currentPoint = newPoint;
    }

    public void InitializationData(SquadItemData squadData)
    {
        health = squadData.health;
        armor = squadData.armor;
        speed = squadData.speed;
        damage = squadData.damage;
        reload = squadData.reload;

    }

}
