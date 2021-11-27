using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    public float PlayerHp;

    public bool CameraLookat;

    public bool IsGameOver;

    void Start()
    {
        IsGameOver = false;
    }

    void Update()
    {
        if(IsGameOver)
        {

        }
    }
}
