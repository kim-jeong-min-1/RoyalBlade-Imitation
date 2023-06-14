using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : PlayerCharacter
{
    public override void Attack()
    {
        
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
        PlayerController.Instance.rigidBody.AddForce(Vector3.up * 30f, ForceMode.Impulse);
    }

    public override void JumpSkill()
    {
        Debug.Log("Jump Skill");
    }
}
