using System.Collections;
using System.Collections.Generic;
using FishNet.Object;
using UnityEngine;

public class Enemy : NetworkBehaviour
{
    public float moveSpeed = 5f;
    private Transform target;
    
    void Start()
    {
        if (IsServer)
        {
            InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }
    }
    
    void UpdateTarget()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestPlayer = null;

        foreach (GameObject player in players)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if (distanceToPlayer < shortestDistance)
            {
                shortestDistance = distanceToPlayer;
                nearestPlayer = player;
            }
        }

        if (nearestPlayer != null)
        {
            target = nearestPlayer.transform;
        }
    }
    
    void Update()
    {
        if(target == null)
        {
            return;
        }
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);
    }
}
