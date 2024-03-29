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
            string skillName = skill.skillName;
            SkillType skillType = skill.skillType;
            switch (skillType)
            {
                case SkillType.Active :
                    if (Input.GetMouseButton(0))
                    {
                        if(skill.lastUsedTime + skill.cooltime < Time.time)
                        {
                            skill.lastUsedTime = Time.time;
                            SpawnBullet(skill.skillPrefab);
                        }
                    }
                    break;
                case SkillType.Passive:
                    if(skill.lastUsedTime + skill.cooltime < Time.time)
                    {
                        skill.lastUsedTime = Time.time;
                        SpawnBullet(skill.skillPrefab);
                    }
                    break;
            }
        }
    }
    
    [ServerRpc]
    public void SpawnBullet(GameObject bulletPrefab)
    {
        if (IsServer)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation;
            
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            if(bulletScript != null)
            {
                bulletScript.direction = transform.up;
                bulletScript.speed = 10f;
            }
            ServerManager.Spawn(bullet);
        }
    }
    
    
}
