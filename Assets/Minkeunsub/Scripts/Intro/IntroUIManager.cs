using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroUIManager : MonoBehaviour
{
    void Start()
    {
        TitleScene();
    }

    void Update()
    {
        
    }

    public void TitleScene()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
