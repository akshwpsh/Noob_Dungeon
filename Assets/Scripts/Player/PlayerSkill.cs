using System.Collections;
using System.Collections.Generic;
using FishNet.Object;
using UnityEngine;

public enum SkillType
{
    Passive,
    Active
}

[CreateAssetMenu(fileName = "New Skill", menuName = "PlayerSkill")]
public class PlayerSkill : ScriptableObject
{
   public string skillName;
   public string skillDescription;
   public SkillType skillType;
   public float cooltime;
   public float lastUsedTime;
   public float speed;
   public int damage;
   public int skillLevel;
   
   public GameObject skillPrefab;
   
}
