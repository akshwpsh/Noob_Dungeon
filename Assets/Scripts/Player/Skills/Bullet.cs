using System;
using System.Collections;
using System.Collections.Generic;
using FishNet.Connection;
using FishNet.Managing.Server;
using FishNet.Object;
using UnityEngine;

public class Bullet : NetworkBehaviour
{
    [HideInInspector]
    public Vector2 direction;
    [HideInInspector]
    public float speed;
    [HideInInspector]
    public int penetration;
    [HideInInspector]
    public float duration;

    private void Update()
    {
        Vector2 normalizedDirection = direction.normalized;
        transform.Translate(normalizedDirection * speed * Time.deltaTime);
        
        duration -= Time.deltaTime;
        if (duration <= 0)
        {
            ServerManager.Despawn(gameObject);
        }
        
        /*
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy <= 0.5f) // Change this value to the desired collision distance
            {
                enemy.GetComponent<Enemy>().TakeDamage(10);
                penetration--;
                if (penetration <= 0)
                {
                    Despawn();
                }
            }
        }*/
        Collider2D[] hitColliders = new Collider2D[10];
        int numColliders = Physics2D.OverlapCircleNonAlloc(transform.position, 1.0f, hitColliders);
        for (int i = 0; i < numColliders; i++)
        {
            Collider2D hitCollider = hitColliders[i];
            if (hitCollider.CompareTag("Enemy"))
            {
                hitCollider.GetComponent<Enemy>().TakeDamage(10);
                penetration--;
                if (penetration <= 0)
                {
                    Despawn();
                }
            }
        }
    }
    public void Despawn()
    {
        TrailRenderer trail = GetComponent<TrailRenderer>();
        trail.emitting = false;
        ServerManager.Despawn(gameObject);
    }

    public void setTrail()
    {
        TrailRenderer trail = GetComponent<TrailRenderer>();
        trail.emitting = true;
    }
    
    
}
