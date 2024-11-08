using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonManager<UIManager>
{
    public Button itemButton;
    public GameObject itemPanel;
    public Button pauseButton;
    public GameObject pausePanel;

    private void Update()
    {
        itemButton.onClick.AddListener(ItemPopupPanel);
        pauseButton.onClick.AddListener(PausePopupPanel);
    } 

    private void ItemPopupPanel()
    {
        itemPanel.SetActive(true);
        Time.timeScale =0f;
    }
    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            PausePopupPanel();
        }
    }
    private void PausePopupPanel()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
