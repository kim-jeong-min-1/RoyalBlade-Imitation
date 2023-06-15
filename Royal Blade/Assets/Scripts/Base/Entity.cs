 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected float maxHp;
    protected float hp;
    protected virtual float HP
    {
        get => hp;
        set
        {
            hp = value;

            if(hp > maxHp) hp = maxHp;
            else if (hp <= 0) Die();
        }
    } 

    public void GetDamage(float damage)
    {
        HP -= damage;
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
