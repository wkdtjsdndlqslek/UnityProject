using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button itemButton;
    public GameObject itemPanel;
    public Button pauseButton;
    public GameObject pausePanel;
    public TextMeshProUGUI levelUptext;
    public TextMeshProUGUI levelUpPrice;
    public GameObject levelUpCooltime;
    public Slider resourcesSlider;
    public TextMeshProUGUI resourcesPercent;
    public GameObject clearPanel;
    public Button clearLobby;
    public GameObject defeatPanel;
    public Button defeatLobby;
    public Button restart;


    private void Update()
    {
        levelUptext.text = $"Lv. {GameManager.Instance.Player.level} LEVEL UP! ";
        resourcesSlider.value = GameManager.Instance.Player.ResourcesFillAmount;
        resourcesPercent.text = $"{GameManager.Instance.Player.resources} / {GameManager.Instance.Player.maxResources}";
        levelUpPrice.text =$"{GameManager.Instance.Player.levelUpPrice}";
        if(GameManager.Instance.Player.level==8)
        {
            GameManager.Instance.Player.levelUpPrice=0;
            levelUpPrice.text="MAX";
        }
        if (GameManager.Instance.Player.levelUpPrice>GameManager.Instance.Player.resources)
        { levelUpCooltime.SetActive(true); }
        else { levelUpCooltime.SetActive(false); }
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
