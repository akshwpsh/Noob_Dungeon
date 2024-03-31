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
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(10);
            penetration--;
            if (penetration <= 0)
            {
                Despawn();
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
