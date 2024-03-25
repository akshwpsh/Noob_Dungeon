using System.Collections;
using System.Collections.Generic;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using UnityEngine;

public class GameRule
{
    public int difficulty = 1;//1 쉬움, 2 보통, 3 어려움
}
public class InGameManager : NetworkBehaviour
{   
    public GameObject enemyPrefab;
    //private readonly SyncList<GameRule> gameRules = new SyncList<GameRule>();
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
    
    public void startSpawn()
    {
        if (IsServer)
        {
            InvokeRepeating("SpawnEnemy", 1f, 1f);
        }
    }
    
    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab);
        ServerManager.Spawn(enemy);
    }
}
