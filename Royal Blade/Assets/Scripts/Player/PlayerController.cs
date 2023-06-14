using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Singleton<PlayerController>
{
    private Player player;
    private Rigidbody rigidBody;

    [SerializeField] private SkillButton jumpButton;
    [SerializeField] private SkillButton attackButton;
    [SerializeField] private Button guardButton;

    private readonly float GUARD_COOL_TIME = 2.5f;
    private float curGuardCool = 2.5f;

    private void Awake()
    {
        player = GetComponent<Player>();
        rigidBody = GetComponent<Rigidbody>();

        SetInstance();
        SetPlayerButton();
    }
    private void Update()
    {
        curGuardCool += Time.deltaTime;
        UIManager.Instance.GuardSkillUI_Update(curGuardCool / GUARD_COOL_TIME);
    }

    public void Jump() => player.character.Jump();
    public void JumpSkill() => player.character.JumpSkill();
    public void Attack() => player.character.Attack();
    public void AttackSkill() => player.character.AttackSkill();
    public void Guard()
    {
        if(curGuardCool >= GUARD_COOL_TIME)
        {
            curGuardCool = 0;
            player.character.Guard();
        }
    }

    private void SetPlayerButton()
    {
        guardButton.onClick.AddListener(Guard);

        jumpButton.ButtonActivate = Jump;
        jumpButton.SlideActivate = JumpSkill;

        attackButton.ButtonActivate = Attack;
        attackButton.SlideActivate = AttackSkill;
    }

    public void SetPlayerCharacter(CharacterData data)
    {
        player.PlayerInit(data);
    }
}
