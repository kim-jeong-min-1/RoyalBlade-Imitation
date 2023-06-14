using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : PlayerCharacter
{
    public override void Attack()
    {
        Debug.Log("Attack");
    }

    public override void AttackSkill()
    {
        Debug.Log("Attack Skill");
    }

    public override void Guard()
    {
        Debug.Log("Guard");
    }

    public override void Jump()
    {
        Debug.Log("Jump");
    }

    public override void JumpSkill()
    {
        Debug.Log("Jump Skill");
    }
}
