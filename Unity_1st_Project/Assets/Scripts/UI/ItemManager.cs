using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
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

    private void Resume()
    {
        itemPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    private void Thunder()
    {
        itemPanel.SetActive(false);
        Time.timeScale = 1f;
        Instantiate(thunderAiming);
        
    }
    private void Hurricane()
    {
        itemPanel.SetActive(false);
        Time.timeScale = 1f;
        Instantiate(hurricane,new Vector2 (8,0.47f),Quaternion.identity);
    }
    private void MonsterStop()
    {
        itemPanel.SetActive(false);
        Time.timeScale = 1f; 
        timeStoptrigger.gameObject.SetActive(true);
    }
    
    private void CanonNoCooltime()
    {
        itemPanel.SetActive(false);
        Time.timeScale = 1f;
        GameManager.Instance.Canon.accessNoCool();
    }
    private void SpawnNoCooltime()
    {
        itemPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
