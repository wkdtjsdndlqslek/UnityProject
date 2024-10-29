using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneCntr : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;

    private void Update()
    {
        startButton.onClick.AddListener(OpenGameScene);
        exitButton.onClick.AddListener(QuitGame);
    }

    private void OpenGameScene()
    {
        SceneManager.LoadScene("StageScene");
    }

    private void QuitGame()
    {
        Application.Quit();
    }

}
