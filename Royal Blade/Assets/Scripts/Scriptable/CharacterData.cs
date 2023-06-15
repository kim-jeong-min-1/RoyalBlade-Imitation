using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character Data", menuName = "Scriptable Object/Character Data", order = 1)]
public class CharacterData : ScriptableObject
{
    [SerializeField]
    private PlayerCharacter character;
    public PlayerCharacter Character { get { return character; } }

    [SerializeField]
    private GameObject weapon;
    public GameObject Weapon { get { return weapon; } }

    [SerializeField] 
    private RuntimeAnimatorController animator;
    public RuntimeAnimatorController Animator { get { return animator; } }

    [SerializeField]
    private float hp;
    public float HP { get { return hp; } }

    [SerializeField]
    private float damage;
    public float Damage { get { return damage; } }

    [SerializeField]
    private float jumpForce;
    public float JumpForce { get { return jumpForce; } }
}
