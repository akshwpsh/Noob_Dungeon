using System.Collections;
using System.Collections.Generic;
using FishNet.Object;
using UnityEngine;

public class MobSpawner : NetworkBehaviour
{
    public GameObject enemyPrefab;
    void Start()
    {

        startSpawn();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void startSpawn()
    {
        if (IsServer)
        {
            InvokeRepeating("SpawnEnemy", 0.5f, 0.5f);
        }
    }
    
    void SpawnEnemy()
    {
        List<Transform> spawnPoints = GetAllChildTransforms(transform.Find("MobSpawnPoints"));
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Count)];
        NetworkObject enemy = NetworkManager.GetPooledInstantiated(enemyPrefab, spawnPoint.position, Quaternion.identity, false);
        ServerManager.Spawn(enemy);
    }
    


    public List<Transform> GetAllChildTransforms(Transform parent)
    {
        List<Transform> result = new List<Transform>();

        foreach (Transform child in parent)
        {
            result.Add(child);
            result.AddRange(GetAllChildTransforms(child));
        }

        return result;
    }
}
