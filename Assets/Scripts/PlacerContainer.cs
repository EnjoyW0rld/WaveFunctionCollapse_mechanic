using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Holds possible objects to spawn on each tile
/// Does hold objects in a way of indices
/// </summary>
public class PlacerContainer
{
    public List<int> _possiblePositions;

    public PlacerContainer(int maxPositions)
    {
        _possiblePositions = new List<int>();
        for (int i = 0; i < maxPositions; i++)
        {
            _possiblePositions.Add(i);
        }
    }

    public bool CanSpawn() => !(_possiblePositions == null || _possiblePositions.Count == 0);
    public int GetRandomInstance() => _possiblePositions[Random.Range(0, _possiblePositions.Count)];
    

    public void ModifyPossibles(int[] pAllowed)
    {
        for (int i = _possiblePositions.Count - 1; i >= 0; i--)
        {
            if (!pAllowed.Contains<int>(_possiblePositions[i]))
            {
                _possiblePositions.RemoveAt(i);
            }
        }
    }
}
