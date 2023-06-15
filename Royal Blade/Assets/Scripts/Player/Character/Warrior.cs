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

    [Header("AttackSkill")]
    [SerializeField] private GameObject attackSkillObject;
    [SerializeField] private Transform attackSkillCenter;
    [SerializeField] private Vector2 attackSkillSize;
    [SerializeField] private float attack_SkillDuration;
    [SerializeField] private float attack_SkillDamage;

    [Header("Effect")]
    [SerializeField] private ParticleSystem attackEffect;
    [SerializeField] private ParticleSystem gaurdEffect;

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
        StartCoroutine(AttackSkill());
        IEnumerator AttackSkill()
        {
            Time.timeScale = 0f;
            attackSkillObject.SetActive(true);
            yield return WaitManager.GetRealWait(1.5f);

            DamageBoxAll(attackCenter.position, attackSkillSize, attack_SkillDamage);
            yield return WaitManager.GetRealWait(0.25f);

            attackSkillObject.SetActive(false);
            Time.timeScale = 1f;        
        }
    }

    public override void JumpSkill()
    {
        StartCoroutine(JumpSkill());
        pController.rigidBody.AddForce(Vector2.up * 100f, ForceMode2D.Impulse);

        IEnumerator JumpSkill()
        {
            jumpSkillObject.SetActive(true);
            float curTime = 0;
            float duration = jump_SkillDuration;

            while (curTime < duration)
            {
                DamageBoxAll(jumpSkillCenter.position, jumpSkillSize, jump_SkillDamage);

                curTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            jumpSkillObject.SetActive(false);
        }
    }

    public override void Guard()
    {
        if (Physics2D.OverlapCircle(transform.position, guardRaidus, LayerMask.GetMask("Drop")))
        {
            DropManager.Instance.KnockBackAll_DropObject();
            Instantiate(gaurdEffect, attackCenter.position, Quaternion.identity);
        }      
    }

    private void DamageBoxAll(Vector2 center, Vector2 size, float damage)
    {
        Collider2D[] collider =
                    Physics2D.OverlapBoxAll(center, size, 0, LayerMask.GetMask("Drop"));

        if (collider.Length > 0)
        {
            for (int i = 0; i < collider.Length; i++)
            {
                collider[i].GetComponent<Entity>().GetDamage(damage);
            }
        }
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackCenter.position, attackSize);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(jumpSkillCenter.position, jumpSkillSize);
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(attackCenter.position, attackSkillSize);
    }
}
