using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private CharacterData warriorData;
    [SerializeField] private CharacterData hunterData;

    void Start()
    {
        PlayerController.Instance.SetPlayerCharacter(warriorData);
        DropManager.Instance.WaveStart(1);
    }

    void Update()
    {
        
    }
}
