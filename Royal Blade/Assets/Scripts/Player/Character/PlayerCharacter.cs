using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerCharacter : MonoBehaviour
{
    protected PlayerController pController => PlayerController.Instance;
    [SerializeField] private float guardRaidus;

    public abstract void Attack();
    public abstract void AttackSkill();
    public abstract void JumpSkill();
    public virtual void Jump()
    {
        pController.rigidBody.AddForce(Vector2.up * pController.player.JumpForce, ForceMode2D.Impulse);
    }
    public virtual void Guard()
    {
        if (Physics2D.OverlapCircle(transform.position, guardRaidus, LayerMask.GetMask("Drop")))
        {
            Debug.Log("Guard!");
        }
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, guardRaidus);
    }
}
