using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Singleton<PlayerController>
{
    [HideInInspector] public Player player;
    [HideInInspector] public Rigidbody2D rigidBody;
    [SerializeField] private SkillButton jumpButton;
    [SerializeField] private SkillButton attackButton;
    [SerializeField] private Button guardButton;

    private readonly float GUARD_COOL_TIME = 2.5f;
    private float curGuardCool = 2.5f;
    private bool isGround = true;

    private void Awake()
    {
        player = GetComponent<Player>();
        rigidBody = GetComponent<Rigidbody2D>();

        SetInstance();
        SetPlayerButton();
    }
    private void Update()
    {
        curGuardCool += Time.deltaTime;
        UIManager.Instance.GuardSkillUI_Update(curGuardCool / GUARD_COOL_TIME);
    }

    #region Input
    public void Jump()
    {
        if (!isGround) return;

        player.character.Jump();
        jumpButton.SkillGaugeUP();
        isGround = false;   
    }
    public void JumpSkill() => player.character.JumpSkill();

    public void Attack()
    {
        player.playerAnimator.SetTrigger("Attack");             
    }
    public void AttackEvent()
    {
        player.character.Attack();
        attackButton.SkillGaugeUP();
    }

    public void AttackSkill() => player.character.AttackSkill();

    public void Guard()
    {
        if(curGuardCool >= GUARD_COOL_TIME)
        {
            curGuardCool = 0;
            player.character.Guard();
        }
    }
    #endregion

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground")) isGround = true;
    }
}
