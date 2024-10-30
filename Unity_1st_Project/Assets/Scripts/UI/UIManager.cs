using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button itemButton;
    public GameObject itemPanel;
    public Button pauseButton;
    public GameObject pausePanel;
    public Slider InGameResources;

    private void Update()
    {
        itemButton.onClick.AddListener(ItemPopupPanel);
        pauseButton.onClick.AddListener(PausePopupPanel);
    } 

    private void ItemPopupPanel()
    {
        itemPanel.SetActive(true);
    }
    private void PausePopupPanel()
    {
        pausePanel.SetActive(true);
    }

}
