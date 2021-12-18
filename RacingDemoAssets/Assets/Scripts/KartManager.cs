using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// Performs some quick assignments to all Karts
/// </summary>
public class KartManager : MonoBehaviour
{
    public SpawnPointManager spawnPointManager;
    public Checkpoints checkpointContainer;
    [HideInInspector]
    public List<KartController> karts;

    public void Awake()
    {
        karts = GetComponentsInChildren<KartController>().ToList();
        foreach (var k in karts) k.checkpointManager.checkpointContainer = checkpointContainer;
    }

    private void Start()
    {
        int i = 0;
        foreach(var k in karts)
        {
            k.spawnPoint = spawnPointManager.spawnPoints[Mathf.Clamp(i, 0, spawnPointManager.spawnPoints.Length - 1)];
            k.spawnPointManager = spawnPointManager;
            ++i;
        }
    }
}
