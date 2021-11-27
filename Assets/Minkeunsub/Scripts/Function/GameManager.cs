using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    public float PlayerHp;

    public bool CameraLookat;

    public bool IsGameOver;

    float lifeTime;
    int killCount;
    int waveCount;
 
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

    public void SetGameEndValue(float _lifetime, int _killCount, int _waveCount)
    {
        lifeTime = _lifetime;
        killCount = _killCount;
        waveCount = _waveCount;
    }
}
