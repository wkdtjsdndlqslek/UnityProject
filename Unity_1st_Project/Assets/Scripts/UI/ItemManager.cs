using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public Button thunderButton;
    public Button hurricaneButton;
    public Button monsterStopButton;
    public Button canonCooltimeButton;
    public Button spawnCooltimeButton;
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
        canonCooltimeButton.onClick.AddListener(CanonCooltime);
        spawnCooltimeButton.onClick.AddListener(SpawnCooltime);
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
    
    private void CanonCooltime()
    {
        itemPanel.SetActive(false);
        Time.timeScale = 1f;
    }
    private void SpawnCooltime()
    {
        itemPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
