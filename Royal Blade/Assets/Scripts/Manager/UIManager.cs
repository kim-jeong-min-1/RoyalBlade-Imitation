using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private Image guardSkillUI;

    private void Awake()
    {
        SetInstance();
    }

    public void GuardSkillUI_Update(float value)
    {
        guardSkillUI.fillAmount = value;
    }
}
