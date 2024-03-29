using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int Health;
    public int AttackPower;
    public int Defense;
    public float WalkSpeed;
    public List<PlayerSkill> Skills = new List<PlayerSkill>();
    public List<int> lastUsedTime = new List<int>();
    
    public PlayerStats(int health, int attackPower, int defense, float walkSpeed)
    {
        Health = health;
        AttackPower = attackPower;
        Defense = defense;
        WalkSpeed = walkSpeed;
    }
    
    public void AddSkill(PlayerSkill skill)
    {
        Skills.Add(skill);
        lastUsedTime.Add(0);
    }
    
    public void RemoveSkill(PlayerSkill skill)
    {
        Skills.Remove(skill);
        lastUsedTime.RemoveAt(Skills.IndexOf(skill));
    }
    
    public bool isCooldownDone(PlayerSkill skill, float time)
    {
        int index = Skills.IndexOf(skill); 
        if (time - lastUsedTime[index] >= skill.cooltime)
        {
            return true;
        }
        return false;
    }
    
    public void UseSkill(PlayerSkill skill)
    {
        int index = Skills.IndexOf(skill);
        lastUsedTime[index] = (int)Time.time;
    }

}
