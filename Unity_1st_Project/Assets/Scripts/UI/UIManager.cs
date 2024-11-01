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
        resourcesSlider.value = GameManager.Instance.Player.ResourcesFillAmount;
        resourcesPercent.text = $"{GameManager.Instance.Player.resources} / {GameManager.Instance.Player.maxResources}";
        itemButton.onClick.AddListener(ItemPopupPanel);
        pauseButton.onClick.AddListener(PausePopupPanel);
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
