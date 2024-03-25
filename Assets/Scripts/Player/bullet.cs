using System.Collections;
using System.Collections.Generic;
using FishNet.Object;
using UnityEngine;

[CreateAssetMenu(fileName = "bullet Skill", menuName = "Skills/bullet")]
public class bullet : PlayerSkill
{
    public override void Use()
    {
        if(Input.GetMouseButton(0))
        {
           Debug.Log("Shoot");
        }
    }
}

