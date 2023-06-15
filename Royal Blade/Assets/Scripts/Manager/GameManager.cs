using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public int Score { get; set; }
    public bool IsGameClear { get; set; }

    private int waveLevel;
    public int WaveLevel
    {
        get => waveLevel;
        set
        {
            if(waveLevel != value) waveLevel = value;
            DropManager.Instance.WaveStart(waveLevel);
        }
    }

    private readonly float GAME_CLEAR_TIME = 180f;
    private float curGameTime = 0f;

    [SerializeField] private CharacterData warriorData; //ภüป็
    [SerializeField] private CharacterData hunterData; //วๅลอ

    void Start()
    {
        PlayerController.Instance.SetPlayerCharacter(warriorData);
        //PlayerController.Instance.SetPlayerCharacter(hunterData);
        WaveLevel++;

        Application.targetFrameRate = 60;
    }

    void Update()
    {
        UIManager.Instance.ScoreText_Update(Score);
        UIManager.Instance.GameProcessBar_Update(curGameTime / GAME_CLEAR_TIME);

        curGameTime += Time.deltaTime;
        if (curGameTime >= GAME_CLEAR_TIME && !IsGameClear)
        {
            GameClear();
            IsGameClear = true;
        }
    }

    public void GameOver() => UIManager.Instance.ResultUI("Game Over!");
    public void GameClear() => UIManager.Instance.ResultUI("Game Clear!");
    public void ReTry() => SceneManager.LoadScene(0);
}
