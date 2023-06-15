using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : PlayerCharacter
{
    [SerializeField] private Transform attackCenter;
    [SerializeField] private Vector2 attackSize;

    public override void Attack()
    {
        Collider2D collider = 
            Physics2D.OverlapBox(attackCenter.position, attackSize, 0, LayerMask.GetMask("Drop"));

        if(collider != null)
        {
            collider.GetComponent<Entity>().GetDamage(pController.player.Damage);
        } 
    }

    public override void AttackSkill()
    {
        Debug.Log("Attack Skill");
    }

    public override void JumpSkill()
    {
        Debug.Log("Jump Skill");
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackCenter.position, attackSize);
    }
}
