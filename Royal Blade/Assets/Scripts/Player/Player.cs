using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public PlayerCharacter character;
    public Animator playerAnimator;
    [SerializeField] private Transform handTransform;

    public float Damage { get; private set; }
    public float JumpForce { get; private set; }

    private void Awake() => playerAnimator = GetComponent<Animator>();

    public void PlayerInit(CharacterData data)
    {
        base.maxHp = data.HP;
        base.hp = base.maxHp;
        Damage = data.Damage;
        JumpForce = data.JumpForce;

        playerAnimator.runtimeAnimatorController = data.Animator;

        character = Instantiate(data.Character, transform);
        Instantiate(data.Weapon, handTransform);
    }

    protected override void Die()
    {
        base.Die();
        GameManager.Instance.GameOver();
    }
}
