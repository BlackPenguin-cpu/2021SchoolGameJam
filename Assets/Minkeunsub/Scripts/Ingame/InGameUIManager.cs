using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIManager : Singleton<InGameUIManager>
{
    public Image skillGauge;
    public Image playerHpImg;
    public Text stageTxt;
    public Text lifetimeTxt;

    int stage;
    float lifeTime;
    float playerHp;
    float maxHp;

    float gaugeMax;
    float gaugeCur;

    protected override void Awake()
    {
        
    }

    void Start()
    {
        maxHp = GameManager.Instance.PlayerHp;
    }

    void Update()
    {
        skillGauge.fillAmount = gaugeCur / gaugeMax;
        playerHpImg.fillAmount = playerHp / maxHp;
        stageTxt.text = "Stage: " + stage.ToString();
        lifetimeTxt.text = "Time: " + string.Format("{0:0.00}", lifeTime);
    }

    public void SetValue(int _stage, float _lifeTime, float _playerHp, float _gaugeMax, float _gaugeCur)
    {
        stage = _stage;
        lifeTime = _lifeTime;
        playerHp = _playerHp;
        gaugeMax = _gaugeMax;
        gaugeCur = _gaugeCur;
    }
}
