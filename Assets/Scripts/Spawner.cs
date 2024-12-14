using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Main script used to spawn objects on the designated area
/// Holds information about possible tiles and to what they can be adjacent
/// </summary>
public class Spawner : MonoBehaviour
{
    [SerializeField] private InstanceSettings[] _instances;
    private PlacerContainer[,] _places;
    [SerializeField] private int _x, _z;

    private void Start()
    {
        FillArray();
        for (int x = 0; x < _x; x++)
        {
            for (int z = 0; z < _z; z++)
            {
                if (_places[x, z].CanSpawn())
                {
                    SpawnObject(x, z);
                }
            }
        }
    }
    /// <summary>
    /// Spawn single tile, does modify positions around it after spawning
    /// </summary>
    /// <param name="px"></param>
    /// <param name="pz"></param>
    private void SpawnObject(int px, int pz)
    {
        int instanceIndex = _places[px, pz].GetRandomInstance();
        InstanceSettings instance = _instances[instanceIndex];
        Instantiate(instance, new Vector3(px * 2, 0, pz * 2), Quaternion.identity).transform.parent = transform;
        EvaluateNeighbours(px, pz,instanceIndex);
    }
    /// <summary>
    /// Modifies neighbouring tiles possible blocks to spawn
    /// </summary>
    /// <param name="px"></param>
    /// <param name="pz"></param>
    /// <param name="pIndex">Index of the block that was just spawned</param>
    private void EvaluateNeighbours(int px, int pz, int pIndex)
    {
        if (px - 1 >= 0)
        {
            _places[px - 1, pz].ModifyPossibles(GameObjectsToIndex(_instances[pIndex].LeftAllowed));
        }
        if (px + 1 < _x)
        {
            _places[px + 1, pz].ModifyPossibles(GameObjectsToIndex(_instances[pIndex].RightAllowed));
        }
    }
    private int GetIndex(InstanceSettings instance)
    {
        return Array.IndexOf(_instances, instance);
    }
    private void FillArray()
    {
        _places = new PlacerContainer[_x, _z];
        for (int x = 0; x < _x; x++)
        {
            for (int z = 0; z < _z; z++)
            {
                _places[x, z] = new PlacerContainer(_instances.Length);
            }
        }
    }
    private int[] GameObjectsToIndex(GameObject[] pObjects)
    {
        int[] indices = new int[pObjects.Length];
        for (int i = 0; i < pObjects.Length; i++)
        {
            indices[i] = Array.IndexOf(_instances, pObjects[i]);
        }
        return indices;
    }
    public int GetIndexOfObject(GameObject pObject)
    {
        return Array.IndexOf(_instances, pObject);
    }
}
