using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObject : Entity
{
    private Rigidbody2D rigidBody => GetComponent<Rigidbody2D>();
    private float knockBackForce = 20f;

    public void DropObjectInit(float hp, float level)
    {
        if(level > 1) base.maxHp = hp + level * 5;
        else base.maxHp = hp;

        base.HP = base.maxHp;
    }

    public void KnockBack()
    {
        rigidBody.AddForce(Vector2.up * knockBackForce, ForceMode2D.Impulse);
    }

    public override void GetDamage(float damage)
    {
        base.GetDamage(damage);
        DamageTextPool.Instance.GetText(transform.position, damage);
    }

    protected override void Die()
    {
        base.Die();
        GameManager.Instance.Score += 200;
    }
}
