using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    public Button resume;
    public GameObject panel;
    private void Start()
    {
        resume.onClick.AddListener(Resume);
    }
    private void Resume()
    {
        panel.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
