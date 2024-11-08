using Lean.Pool;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemPanel : MonoBehaviour
{
    public int thunderCost=10;
    public int hurricaneCost=20;
    public int monsterStopCost=40;
    public int canonNoCoolCost=30;
    public int spawnNoCoolCost=90;
    public TextMeshProUGUI currentCash;
    public Button thunderButton;
    public Button hurricaneButton;
    public Button monsterStopButton;
    public Button canonNoCooltimeButton;
    public Button spawnNoCooltimeButton;
    public Button resumeButton;
    public GameObject itemPanel;
    public ThunderAim thunderAiming;
    public Hurricane hurricane;
    public TimeStoptrigger timeStoptrigger;

    private void Start()
    {
        resumeButton.onClick.AddListener(Resume);
        thunderButton.onClick.AddListener(Thunder);
        hurricaneButton.onClick.AddListener(Hurricane);
        monsterStopButton.onClick.AddListener(MonsterStop);
        canonNoCooltimeButton.onClick.AddListener(CanonNoCooltime);
        spawnNoCooltimeButton.onClick.AddListener(SpawnNoCooltime);
    }

    private void Update()
    {
        currentCash.text=$"{GameManager.Instance.Player.cash}";
    }

    private void Resume()
    {
        itemPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    private void Thunder()
    {
        if (GameManager.Instance.Player.cash>=thunderCost)
        {
            itemPanel.SetActive(false);
            Time.timeScale = 1f;
            LeanPool.Spawn(thunderAiming);
            GameManager.Instance.Player.cash -= thunderCost;
        }
        else
        {
        }
    }
    private void Hurricane()
    {
        if (GameManager.Instance.Player.cash>=hurricaneCost)
        {
            itemPanel.SetActive(false);
            Time.timeScale = 1f;
            LeanPool.Spawn(hurricane, new Vector2(8, 0.47f), Quaternion.identity);
            GameManager.Instance.Player.cash -=hurricaneCost;
        }
        else
        {
        }
    }
    private void MonsterStop()
    {
        if (GameManager.Instance.Player.cash>=monsterStopCost&&timeStoptrigger.gameObject.activeSelf==false)
        {
            itemPanel.SetActive(false);
            Time.timeScale = 1f;
            timeStoptrigger.gameObject.SetActive(true);
            GameManager.Instance.Player.cash -=monsterStopCost;
        }
        else
        {
        }
    }
    
    private void CanonNoCooltime()
    {
        if (GameManager.Instance.Player.cash>=canonNoCoolCost)
        {
            itemPanel.SetActive(false);
            Time.timeScale = 1f;
            GameManager.Instance.Canon.accessNoCool();
            GameManager.Instance.Player.cash -=canonNoCoolCost;
        }
        else
        {
        }
    }
    private void SpawnNoCooltime()
    {
        if (GameManager.Instance.Player.cash>=spawnNoCoolCost)
        {
            itemPanel.SetActive(false);
            Time.timeScale = 1f;
            GameManager.Instance.UnitSpawner.accessNoCool();
            GameManager.Instance.Player.cash -= spawnNoCoolCost;
        }
        else
        {
        }
    }
}
