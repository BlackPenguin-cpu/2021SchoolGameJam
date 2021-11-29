using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIManager : Singleton<InGameUIManager>
{
    [Header("Status UI")]
    public Image ingame_skillGauge;
    public Image ingame_playerHpImg;
    public Text ingame_stageTxt;
    public Text ingame_lifetimeTxt;

    [Header("Game Over UI")]
    public GameObject GameoverObject;
    public Image[] gameover_Messages; //0: title, 1~3: variables, 4: result
    public Text[] gameover_MessagesTxt; //0~2: variables
    public string[] s_MessagesTxt; //0~2: variables
    public Image[] gameover_ResultImg; //0: Failed, 1: Successed
    public Image[] gameover_successIcons;
    public Image[] gameover_failedIcons;

    public int stage;
    float lifeTime;
    float playerHp;
    float maxHp;
    int killcount;
    float gaugeMax;
    float gaugeCur;

    public bool gameSuccess;

    protected override void Awake()
    {

    }

    void Start()
    {
        maxHp = GameManager.Instance.PlayerHp;
        DeActiveObj();
    }

    void MessageTxtInitial()
    {
        s_MessagesTxt[0] = string.Format("{0:0.00}", lifeTime);
        s_MessagesTxt[1] = stage.ToString();
        s_MessagesTxt[2] = killcount.ToString();
    }

    void DeActiveObj()
    {
        foreach (var item in gameover_Messages)
        {
            item.gameObject.SetActive(false);
        }
        foreach (var item in gameover_ResultImg)
        {
            item.gameObject.SetActive(false);
        }
        foreach (var item in gameover_successIcons)
        {
            item.gameObject.SetActive(false);
        }
        foreach (var item in gameover_failedIcons)
        {
            item.gameObject.SetActive(false);
        }
        GameoverObject.SetActive(false);
    }

    void Update()
    {
        ingame_skillGauge.fillAmount = 1 - gaugeCur / gaugeMax;
        ingame_playerHpImg.fillAmount = playerHp / maxHp;
        ingame_stageTxt.text = "Stage: " + stage.ToString();
        ingame_lifetimeTxt.text = "Time: " + string.Format("{0:0.00}", lifeTime);
    }

    IEnumerator GameResult()
    {
        yield return null;
        GameoverObject.SetActive(true);
        yield return new WaitForSeconds(2f);

        //title
        gameover_Messages[0].gameObject.SetActive(true);
        yield return new WaitForSeconds(1);

        //messages
        for (int i = 0; i < s_MessagesTxt.Length; i++)
        {
            gameover_Messages[i + 1].gameObject.SetActive(true);
            yield return new WaitForSeconds(1f);
            for (int j = 0; j < s_MessagesTxt[i].Length; j++)
            {
                gameover_MessagesTxt[i].text += s_MessagesTxt[i][j];
                yield return null;
            }
            yield return new WaitForSeconds(0.5f);
            if (gameSuccess)
            {
                gameover_successIcons[i].gameObject.SetActive(true);
            }
            else
            {
                gameover_failedIcons[i].gameObject.SetActive(true);
            }
            yield return new WaitForSeconds(1f);
        }

        //result
        yield return new WaitForSeconds(1f);
        gameover_Messages[4].gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        if (gameSuccess)
        {
            gameover_ResultImg[1].gameObject.SetActive(true);
        }
        else
        {
            gameover_ResultImg[0].gameObject.SetActive(true);
        }
    }

    public void GameOver()
    {
        MessageTxtInitial();
        StartCoroutine(GameResult());
    }

    public void SetValue(int _stage, float _lifeTime, float _playerHp, float _gaugeMax, float _gaugeCur, int _killCount)
    {
        stage = _stage;
        lifeTime = _lifeTime;
        playerHp = _playerHp;
        gaugeMax = _gaugeMax;
        gaugeCur = _gaugeCur;
        killcount = _killCount;
    }


}
