using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    public System.Action ButtonActivate;
    public System.Action SlideActivate;

    [SerializeField] private int MAX_SKILL_GAUGE;
    private float skillGauge;
    public float CurSkillGauge
    {
        get => skillGauge;
        set
        {
            skillGauge = value;
            skill_GaugeImage.fillAmount = skillGauge / MAX_SKILL_GAUGE;

            if (skillGauge == MAX_SKILL_GAUGE)
            {
                isSkillOn = true;
                SetSkillUI(true);
            }
        }
    }

    private bool isSkillOn = false;
    [SerializeField] private Slider skill_DragUI;
    [SerializeField] private Image skill_GaugeImage;
    [SerializeField] private Image backgroundUI;

    private void Update()
    {
        if (isSkillOn)
        {
            if (skill_DragUI.value >= 1f) UseSkill();

            if (Input.GetMouseButtonUp(0) && skill_DragUI.value > 0f)
            {
                skill_DragUI.value = 0f;
            }
        }
    }

    public void PressButton()
    {
        ButtonActivate();
    }
    public void SkillGaugeUP()
    {
        CurSkillGauge++;
    }

    private void SetSkillUI(bool active)
    {
        backgroundUI.gameObject.SetActive(active);
        skill_DragUI.interactable = active;
    }

    private void UseSkill()
    {
        SlideActivate();

        CurSkillGauge = 0f;
        skill_DragUI.value = 0f;

        isSkillOn = false;
        SetSkillUI(false);
    }
}
