using System.Collections;
using System.Collections.Generic;
using FishNet.Object;
using UnityEngine;

public class Enemy : NetworkBehaviour
{
    public int health = 20;
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
        if(!IsServer)
            return;
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

        if (nearestPlayer != null && shortestDistance <= 30)
        {
            target = nearestPlayer.transform;
        }
        else if (players.Length > 0)
        {
            // If the nearest player is too far away, teleport to a random player.
            int randomIndex = Random.Range(0, players.Length);
            Transform randomPlayer = players[randomIndex].transform;
            List<Transform> points =  randomPlayer.GetComponent<MobSpawner>().GetAllChildTransforms(randomPlayer.Find("MobSpawnPoints"));
            Transform point = points[Random.Range(0, points.Count)];
            transform.position = point.position;
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
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            if (IsServer)
            {
                Die();
            }
        }
    }
    
    void Die()
    {
        ServerManager.Despawn(gameObject);
    }
}
