using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : Entity
{
    public PlayerCharacter character;
    private Animator playerAnimator;
    [SerializeField] private Image playerHpBar;
    [SerializeField] private TextMeshProUGUI playerHpText;
    [SerializeField] private Transform handTransform;

    protected override float HP
    {
        get => base.hp;
        set
        {
            base.hp = value;
            playerHpBar.fillAmount = hp / maxHp;
            playerHpText.text = $"{hp}/{maxHp}";
        }
    }
    public float Damage { get; private set; }

    private void Awake() => playerAnimator = GetComponent<Animator>();

    public void PlayerInit(CharacterData data)
    {
        base.maxHp = data.HP;
        base.hp = base.maxHp;
        Damage = data.Damage;

        playerAnimator.runtimeAnimatorController = data.Animator;
        character = data.Character;

        Instantiate(data.Weapon, handTransform);
    }
}
