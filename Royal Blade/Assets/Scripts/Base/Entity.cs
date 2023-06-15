 using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private Image playerHpBar;
    [SerializeField] private TextMeshProUGUI playerHpText;

    protected float maxHp;
    protected float hp;
    public float HP
    {
        get => hp;
        set
        {
            hp = value;
            if (hp <= 0) Die();

            playerHpBar.fillAmount = hp / maxHp;
            playerHpText.text = $"{hp}/{maxHp}";
        }
    }
    public bool isDie { get; private set; }

    public virtual void GetDamage(float damage)
    {
        HP -= damage;
    }

    protected virtual void Die()
    {
        isDie = true;
        Destroy(gameObject);
    }
}
