using System.Collections;
using System.Collections.Generic;
using FishNet.Object;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    public static PlayerController Instance;
    private PlayerStats playerStats;

    public PlayerSkill testSkill;
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        playerStats.AddSkill(testSkill);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsOwner)
        {
            Instance = this;
        }
           
        Move();
        UseSkill();
    }

    public void Move()
    {
        if (base.IsOwner)
        {
            float walkSpeed = playerStats.WalkSpeed;
            if(Input.GetKey(KeyCode.W))
            {
                transform.position += transform.up * walkSpeed * Time.deltaTime;
            }
            if(Input.GetKey(KeyCode.S))
            {
                transform.position -= transform.up * walkSpeed * Time.deltaTime;
            }
            if(Input.GetKey(KeyCode.A))
            {
                transform.position -= transform.right * walkSpeed * Time.deltaTime;
            }
            if(Input.GetKey(KeyCode.D))
            {
                transform.position += transform.right * walkSpeed * Time.deltaTime;
            }
        }
    }
    
    public void UseSkill()
    {
        foreach (PlayerSkill skill in playerStats.Skills)
        {
            if(playerStats.isCooldownDone(skill, Time.time))
            {
                playerStats.UseSkill(skill);
                Vector2 dir = Vector2.zero;
                switch (skill.skillTarget)
                {
                    case SkillTarget.Mouse:
                        dir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        break;
                    case SkillTarget.ClosestEnemy:
                        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                        float shortestDistance = Mathf.Infinity;
                        GameObject nearestEnemy = null;
                        foreach (GameObject enemy in enemies)
                        {
                            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                            if (distanceToEnemy < shortestDistance)
                            {
                                shortestDistance = distanceToEnemy;
                                nearestEnemy = enemy;
                            }
                        }
                        if (nearestEnemy != null)
                        {
                            dir = nearestEnemy.transform.position - transform.position;
                        }
                        break;
                    case SkillTarget.RandomEnemy:
                        GameObject[] enemies2 = GameObject.FindGameObjectsWithTag("Enemy");
                        if (enemies2.Length > 0)
                        {
                            int randomIndex = Random.Range(0, enemies2.Length);
                            dir = enemies2[randomIndex].transform.position - transform.position;
                        }
                        break;
                    case SkillTarget.ClosetPlayer:
                        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
                        float shortestDistance2 = Mathf.Infinity;
                        GameObject nearestPlayer = null;
                        foreach (GameObject player in players)
                        {
                            if(player == gameObject)
                                continue;
                            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
                            if (distanceToPlayer < shortestDistance2)
                            {
                                shortestDistance2 = distanceToPlayer;
                                nearestPlayer = player;
                            }
                        }
                        if (nearestPlayer != null)
                        {
                            dir = nearestPlayer.transform.position - transform.position;
                        }
                        break;
                }
                SpawnBullet(skill.skillPrefab, skill,dir);
            }
        }
    }

    [ServerRpc]
    public void SpawnBullet(GameObject bulletPrefab, PlayerSkill skill, Vector2 dir = default)
    {
        if (IsServer)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;

            Bullet bulletScript = bullet.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                bulletScript.direction = dir.normalized;
                bulletScript.speed = skill.speed;
                bulletScript.penetration = skill.penetration;
                bulletScript.duration = skill.duration;
            }

            ServerManager.Spawn(bullet);
        }
    }


}
