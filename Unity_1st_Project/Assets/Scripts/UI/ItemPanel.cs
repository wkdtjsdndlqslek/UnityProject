using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPanel : MonoBehaviour
{
    public Button thunder;
    public Button hurricane;
    public Button hourglass;
    public Button towerCooltime;
    public Button spawnCooltime;
    public Button resumeButton;
    public GameObject itemPanel;

    private void Start()
    {
        thunder.onClick.AddListener(BuyThunder);
        hurricane.onClick.AddListener(BuyHurricane);
        hourglass.onClick.AddListener(BuyHourglass);
        towerCooltime.onClick.AddListener(BuyTowerCooltime);
        spawnCooltime.onClick.AddListener(BuySpawnCooltime);
        resumeButton.onClick.AddListener(Resume);
    }

    private void BuyThunder()
    {

    }
    private void BuyHurricane()
    {

    }
    private void BuyHourglass()
    {

    }
    private void BuyTowerCooltime()
    {

    }
    private void BuySpawnCooltime()
    {

    }
    private void Resume()
    {
        itemPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
