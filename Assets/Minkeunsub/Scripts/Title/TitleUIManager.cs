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
    [SerializeField] Button checkboxButton;
    [SerializeField] Image check;

    void Start()
    {
        HowToPlayObj.SetActive(false);
    }

    void Update()
    {
        check.gameObject.SetActive(GameManager.Instance.CameraLookat);
    }

    public void Ingame()
    {
        SceneManager.LoadScene("InGameScene");
    }

    public void HowtoPlay()
    {
        HowToPlayObj.SetActive(true);
    }

    public void CloseHowtoPlay()
    {
        HowToPlayObj.SetActive(false);
    }

    public void CheckBox()
    {
        GameManager.Instance.CameraLookat = !GameManager.Instance.CameraLookat;
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}
