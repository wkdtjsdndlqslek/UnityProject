using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button itemButton;
    public GameObject itemPanel;
    public Button pauseButton;
    public GameObject pausePanel;
    public Slider resourcesSlider;
    public TextMeshProUGUI resourcesPercent;

    private void Update()
    {
        itemButton.onClick.AddListener(ItemPopupPanel);
        pauseButton.onClick.AddListener(PausePopupPanel);
        resourcesSlider.value = GameManager.Instance.player.ResourcesFillAmount;
        resourcesPercent.text = $"{GameManager.Instance.player.resources} / {GameManager.Instance.player.maxResources}";
    } 

    private void ItemPopupPanel()
    {
        itemPanel.SetActive(true);
        Time.timeScale =0f;
    }
    private void PausePopupPanel()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

}
