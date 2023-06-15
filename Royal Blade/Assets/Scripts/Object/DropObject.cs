using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObject : Entity
{
    private Rigidbody2D rigidBody => GetComponent<Rigidbody2D>();

    public void DropObjectInit(float hp, float level)
    {
        base.maxHp = hp;
        base.hp = hp;

        float speedMult = level * 0.05f;
        rigidBody.gravityScale += speedMult;
    }

    public void KnockBack()
    {
        //가드 당했을때 넉백
    }
}
