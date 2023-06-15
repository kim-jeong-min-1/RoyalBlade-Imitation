using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : PlayerCharacter
{
    [Header("Attack")]
    [SerializeField] private Transform attackCenter;
    [SerializeField] private Vector2 attackSize;
    [Space(20)]

    [Header("JumpSkill")]
    [SerializeField] private GameObject jumpSkillObject;
    [SerializeField] private Transform jumpSkillCenter;
    [SerializeField] private Vector2 jumpSkillSize;
    [SerializeField] private float jump_SkillDuration;
    [SerializeField] private float jump_SkillDamage;
    [Space(20)]

    [Header("Effect")]
    [SerializeField] private ParticleSystem attackEffect;

    public override void Attack()
    {
        Collider2D collider =
            Physics2D.OverlapBox(attackCenter.position, attackSize, 0, LayerMask.GetMask("Drop"));

        if (collider != null)
        {
            collider.GetComponent<Entity>().GetDamage(pController.player.Damage);
            Instantiate(attackEffect, collider.transform.position, Quaternion.identity);
        }
    }

    public override void AttackSkill()
    {
        Debug.Log("Attack Skill");
    }

    public override void JumpSkill()
    {
        StartCoroutine(JumpSkill());
        pController.rigidBody.AddForce(Vector2.up * 120f, ForceMode2D.Impulse);

        IEnumerator JumpSkill()
        {
            jumpSkillObject.SetActive(true);
            float curTime = 0;
            float duration = jump_SkillDuration;

            while (curTime < duration)
            {
                Collider2D[] collider =
                    Physics2D.OverlapBoxAll(attackCenter.position, attackSize, 0, LayerMask.GetMask("Drop"));

                if (collider.Length > 0)
                {
                    for (int i = 0; i < collider.Length; i++)
                    {
                        collider[i].GetComponent<Entity>().GetDamage(jump_SkillDamage);
                    }
                }
                curTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            jumpSkillObject.SetActive(false);
        }
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackCenter.position, attackSize);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(jumpSkillCenter.position, jumpSkillSize);
    }
}
