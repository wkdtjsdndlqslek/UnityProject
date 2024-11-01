using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneCntr : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;

    private void Awake()
    {
        GameManager.Instance.timeClear();
    }
    private void Start()
    {
        startButton.onClick.AddListener(OpenGameScene);
        exitButton.onClick.AddListener(QuitGame);
    }

    private void OpenGameScene()
    {
        SceneManager.LoadScene("StageScene");
        Time.timeScale = 1.0f;
        
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
