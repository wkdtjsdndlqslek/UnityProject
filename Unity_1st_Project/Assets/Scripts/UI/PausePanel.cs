using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    public Button resume;
    public Button lobby;
    public GameObject panel;
    public TextMeshProUGUI currentTime;

    private void Start()
    {
        resume.onClick.AddListener(Resume);
        lobby.onClick.AddListener(Lobby);
        Time.timeScale = 0f;
    }
    private void Update()
    {
        currentTime.text = string.Format("{0:D2}:{1:D2}",GameManager.Instance.min,(int)GameManager.Instance.sec);
    }
    private void Resume()
    {
        panel.SetActive(false);
        Time.timeScale = 1.0f;
    }
    private void Lobby()
    {
        GameManager.Instance.Reset();

        SceneManager.LoadScene("StartScene");
    }
    
}
