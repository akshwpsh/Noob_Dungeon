using System.Collections;
using System.Collections.Generic;
using FishNet.Object;
using UnityEngine;

public enum SkillType
{
    Passive,
    Active
}

public abstract class PlayerSkill : NetworkBehaviour
{
   public string skillName;
   public string skillDescription;
   public SkillType skillType;
   public GameObject skillPrefab;
    
   public abstract void Use();
}
