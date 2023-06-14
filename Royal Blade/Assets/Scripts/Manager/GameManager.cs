using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CharacterData warriorData;

    void Start()
    {
        PlayerController.Instance.SetPlayerCharacter(warriorData);
    }

    void Update()
    {
        
    }
}
