using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private Image hitUI;
    [SerializeField] private Image guardSkillUI;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text resultText;
    [SerializeField] private Slider gameProcessBar;
    [SerializeField] private GameObject resultUI;

    private void Awake()
    {
        SetInstance();
    }

    public void ScoreText_Update(int score)
    {
        scoreText.text = $"{score}";
    }

    public void HitUIOn()
    {
        StartCoroutine(HitUI());
        IEnumerator HitUI()
        {
            hitUI.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.15f);
            hitUI.gameObject.SetActive(false);
        }
    }

    public void GuardSkillUI_Update(float value)
    {
        guardSkillUI.fillAmount = value;
    }

    public void GameProcessBar_Update(float value)
    {
        gameProcessBar.value = value;
    }

    public void ResultUI(string result)
    {
        resultText.text = result;
        resultUI.gameObject.SetActive(true);
    }
}

