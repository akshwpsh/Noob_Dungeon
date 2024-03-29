using System.Collections;
using System.Collections.Generic;
using FishNet.Object;
using UnityEngine;

public enum SkillTarget
{
    Mouse,
    ClosetPlayer,
    ClosestEnemy,
    RandomEnemy,
}

[CreateAssetMenu(fileName = "New Skill", menuName = "PlayerSkill")]
public class PlayerSkill : ScriptableObject
{
   public string skillName;
   public string skillDescription;
   public SkillTarget skillTarget;
   public float cooltime;
   public float speed;
   public int damage;
   public int penetration;
   public int skillLevel;
   public float duration;
   public GameObject skillPrefab;
   
}
