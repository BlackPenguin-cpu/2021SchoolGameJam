using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUIManager : MonoBehaviour
{

    [SerializeField] GameObject HowToPlayObj;

    void Start()
    {
        HowToPlayObj.SetActive(false);
    }

    void Update()
    {

    }

    public void Ingame()
    {
        SceneManager.LoadScene("TestScene");
    }

    public void HowtoPlay()
    {
        HowToPlayObj.SetActive(true);
    }

    public void CloseHowtoPlay()
    {
        HowToPlayObj.SetActive(false);
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
