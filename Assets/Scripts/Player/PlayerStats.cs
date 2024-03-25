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
    }
    
    public void RemoveSkill(PlayerSkill skill)
    {
        Skills.Remove(skill);
    }
}
