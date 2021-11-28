using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIManager : Singleton<InGameUIManager>
{
    [Header("Status UI")]
    public Image skillGauge;
    public Image playerHpImg;
    public Text stageTxt;
    public Text lifetimeTxt;

    [Header("Game Over UI")]
    public GameObject GameOverObject;
    public Text titleTxt;
    public Text lifeTimeTxt;
    public Text killCountTxt;
    public Text surviveWaveTxt;
    public Text resultTxt;

    string title;
    string Lifetime;
    string Killcount;
    string Survivewave;
    string Result;

    int stage;
    float lifeTime;
    float playerHp;
    float maxHp;
    int killcount;
    float gaugeMax;
    float gaugeCur;

    protected override void Awake()
    {

    }

    void Start()
    {
        maxHp = GameManager.Instance.PlayerHp;
        GameOverObject.SetActive(false);
    }

    void Update()
    {

        skillGauge.fillAmount = gaugeCur / gaugeMax;
        playerHpImg.fillAmount = playerHp / maxHp;
        stageTxt.text = "Stage: " + stage.ToString();
        lifetimeTxt.text = "Time: " + string.Format("{0:0.00}", lifeTime);
    }

    public void GameOver()
    {
        GameOverResult();
        StartCoroutine(GameOverText());
    }

    public void GameOverResult()
    {
        title = @"치료제 테스트 결과";
        Lifetime = @"생존시간: ?" + string.Format("{0:0.00}", lifeTime).ToString() + "초";
        Debug.Log(Lifetime);
        Killcount = @"박멸한 바이러스 수: ?" + killcount.ToString() + "마리";
        Survivewave = @"생존한 웨이브: ?" + stage.ToString() + "회";
        Result = @"테스트 결과: ?Failed";
        GameOverObject.SetActive(true);
    }

    public IEnumerator GameOverText()
    {
        for (int i = 0; i < title.Length; i++)
        {
            titleTxt.text += title[i];
            yield return new WaitForSecondsRealtime(0.05f);
        }
        yield return new WaitForSecondsRealtime(1f);

        string s_temp = Lifetime;
        string[] s_arr = s_temp.Split('?');
        for (int i = 0; i < s_arr[0].Length; i++)
        {
            lifeTimeTxt.text += s_arr[0][i];
            yield return new WaitForSecondsRealtime(0.05f);
        }
        yield return new WaitForSecondsRealtime(1f);

        for (int i = 0; i < s_arr[1].Length; i++)
        {
            lifeTimeTxt.text += s_arr[1][i];
            yield return new WaitForSecondsRealtime(0.05f);
        }
        yield return new WaitForSecondsRealtime(1f);

        s_temp = Killcount;
        s_arr = s_temp.Split('?');
        for (int i = 0; i < s_arr[0].Length; i++)
        {
            killCountTxt.text += s_arr[0][i];
            yield return new WaitForSecondsRealtime(0.05f);
        }
        yield return new WaitForSecondsRealtime(1f);

        for (int i = 0; i < s_arr[1].Length; i++)
        {
            killCountTxt.text += s_arr[1][i];
            yield return new WaitForSecondsRealtime(0.05f);
        }
        yield return new WaitForSecondsRealtime(1f);

        s_temp = Survivewave;
        s_arr = s_temp.Split('?');
        for (int i = 0; i < s_arr[0].Length; i++)
        {
            surviveWaveTxt.text += s_arr[0][i];
            yield return new WaitForSecondsRealtime(0.05f);
        }
        yield return new WaitForSecondsRealtime(1f);

        for (int i = 0; i < s_arr[1].Length; i++)
        {
            surviveWaveTxt.text += s_arr[1][i];
            yield return new WaitForSecondsRealtime(0.05f);
        }
        yield return new WaitForSecondsRealtime(3);

        s_temp = Result;
        s_arr = s_temp.Split('?');
        for (int i = 0; i < s_arr[0].Length; i++)
        {
            resultTxt.text += s_arr[0][i];
            yield return new WaitForSecondsRealtime(0.05f);
        }
        yield return new WaitForSecondsRealtime(3f);
        for (int i = 0; i < s_arr[1].Length; i++)
        {
            resultTxt.text += s_arr[1][i];
            yield return new WaitForSecondsRealtime(0.05f);
        }
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
