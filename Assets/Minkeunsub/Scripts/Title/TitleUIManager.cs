using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleUIManager : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] GameObject HowToPlayObj;

    [Header("Checkbox")]
    [SerializeField] Image check;

    [Header("Sound")]
    [SerializeField] AudioClip background_music;
    [SerializeField] AudioClip Button_Sound;
    [SerializeField] AudioClip Exit_Button_Sound;

    void Start()
    {
        HowToPlayObj.SetActive(false);
    }

    void Update()
    {
        check.gameObject.SetActive(GameManager.Instance.CameraLookat);
        if (Input.GetKeyDown(KeyCode.Escape) && HowToPlayObj.activeSelf)
        {
            CloseHowtoPlay();
        }
    }

    public void Ingame()
    {
        SoundManager.Instance.PlaySound(Button_Sound);
        SceneManager.LoadScene("InGameScene");
    }

    public void HowtoPlay()
    {
        SoundManager.Instance.PlaySound(Button_Sound);
        HowToPlayObj.SetActive(true);
    }

    public void CloseHowtoPlay()
    {
        SoundManager.Instance.PlaySound(Exit_Button_Sound);
        HowToPlayObj.SetActive(false);
    }

    public void CheckBox()
    {
        GameManager.Instance.CameraLookat = !GameManager.Instance.CameraLookat;
    }

    public void ExitGame()
    {
        SoundManager.Instance.PlaySound(Button_Sound);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}
