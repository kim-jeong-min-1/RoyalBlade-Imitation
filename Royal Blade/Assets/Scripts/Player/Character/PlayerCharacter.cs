using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerCharacter : MonoBehaviour
{
    public abstract void Attack();
    public abstract void Jump();
    public abstract void AttackSkill();
    public abstract void JumpSkill();
    public abstract void Guard();
}
