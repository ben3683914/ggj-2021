using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnPointManager : MonoBehaviour
{
    public static SpawnPointManager Instance;
    public Transform SpawnPoints;
    public Transform BoxPoints;
    private List<Transform> OpenSpawns;
    private List<Transform> UsedSpawns;
    [SerializeField]
    private List<Transform> BoxSpawns;
    [SerializeField]
    private List<Transform> UsedBoxSpawns;

    private void Awake()
    {
        Instance = this;
        OpenSpawns = new List<Transform>();
        UsedSpawns = new List<Transform>();
        BoxSpawns = new List<Transform>();
        UsedBoxSpawns = new List<Transform>();

        // populate initial list of spawns
        var points = SpawnPoints.GetComponentsInChildren<SpawnPoint>();
        foreach(var point in points)
        {
            OpenSpawns.Add(point.GetComponent<Transform>());
        }

        var boxPoints = BoxPoints.GetComponentsInChildren<SpawnPoint>();
        foreach (var point in boxPoints)
        {
            BoxSpawns.Add(point.GetComponent<Transform>());
        }

        PlaceBoxes();
    }

    public Transform GetSpawn()
    {
        var spawn = OpenSpawns[Random.Range(0, OpenSpawns.Count)];
        OpenSpawns.Remove(spawn);
        UsedSpawns.Add(spawn);
        return spawn;
    }

    public Transform GetBoxSpawn()
    {
        var spawn = BoxSpawns[Random.Range(0, BoxSpawns.Count)];
        BoxSpawns.Remove(spawn);
        UsedBoxSpawns.Add(spawn);
        return spawn;
    }

    public void PlaceBoxes()
    {
        // spawn boxes
        Instantiate(Resources.Load("Prefabs/box1"), GetBoxSpawn());
        Instantiate(Resources.Load("Prefabs/box2"), GetBoxSpawn());
        Instantiate(Resources.Load("Prefabs/box3"), GetBoxSpawn());
    }
}
