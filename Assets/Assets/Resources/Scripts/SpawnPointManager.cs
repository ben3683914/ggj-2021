using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnPointManager : MonoBehaviour
{
    public Transform SpawnPoints;
    [SerializeField]
    private List<Transform> OpenSpawns;
    [SerializeField]
    private List<Transform> UsedSpawns;

    private void Awake()
    {
        OpenSpawns = new List<Transform>();
        UsedSpawns = new List<Transform>();

        // populate initial list of spawns
        var points = SpawnPoints.GetComponentsInChildren<SpawnPoint>();
        foreach(var point in points)
        {
            OpenSpawns.Add(point.GetComponent<Transform>());
        }

        var test = GetSpawn();
    }

    public Transform GetSpawn()
    {
        var spawn = OpenSpawns[Random.Range(0, OpenSpawns.Count)];
        OpenSpawns.Remove(spawn);
        UsedSpawns.Add(spawn);
        return spawn;
    }
}
