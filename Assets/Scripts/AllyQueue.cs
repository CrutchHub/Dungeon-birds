using System.Collections.Generic;
using UnityEngine;

public class AllyQueue : MonoBehaviour
{
    [SerializeField] private List<Rigidbody> alliedUnits;

    public Rigidbody GetNextAlly()
    {
        if (alliedUnits.Count == 0) return null;
        Rigidbody ally = alliedUnits[0];
        alliedUnits.RemoveAt(0);
        if (alliedUnits.Count == 0) { Debug.Log("Allies are over"); } 
        return ally;
    }
}
