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
        if (base.IsOwner)
        {
            foreach (PlayerSkill skill in playerStats.Skills)
            {
                if (skill.skillType == SkillType.Active)
                {
                    skill.Use();
                }
            }
        }
    }
    
}
