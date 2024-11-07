using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : Unit
{
    public float farmingAmount = 20f;
    public float farmingDuration = 3f;
    public float resources = 0f;
    public float maxResources = 1000f;
    public float ResourcesFillAmount { get { return resources/maxResources; } }
    public int level = 1;
    public Button levelUp;
    public int cash = 1000;
    public int _hp = 3000;
    public TextMeshProUGUI hpText;
    public int skillDamage;
    public int levelUpPrice = 180;
    public GameObject defeatPanel;
    public Button defeatLobby;
    public Button restart;

    protected override void Awake()
    {
        hp =_hp;
        base.Awake();
        knockBackDistance = 0f;
        knockBackHpRatio = 0f;
    }
    private void Start()
    {
        levelUp.onClick.AddListener(LevelUp);
        GameManager.Instance.Player = this;
        StartCoroutine(Farming());
    }

    protected override void Update()
    {
        hpText.text = $"{hp}/{maxHp}";
        fillImage.fillAmount = HpFillAmount;
    }

    IEnumerator Farming()
    {
        while (true)
        {
            yield return new WaitForSeconds(farmingDuration);
            if (resources<maxResources)
            {
                resources += farmingAmount;
            }
            else if (resources+maxResources>maxResources)
            {
                resources = maxResources;
            }
        }
    }

    private void LevelUp()
    {
        if (level==8)
        { }
        else if (resources>levelUpPrice)
        {
            resources -= levelUpPrice;
            maxResources+=500;
            farmingAmount +=20;
            levelUpPrice+=180;
            level++;
        }
    }

    protected override void Die()
    {
        Time.timeScale =0f;
        defeatPanel.SetActive(true);
        defeatLobby.onClick.AddListener(Lobby);
        restart.onClick.AddListener(Restart);
    }

    private void Lobby()
    {
        GameManager.Instance.playerList.Clear();
        GameManager.Instance.enemyList.Clear();
        GameManager.Instance.Player=null;
        GameManager.Instance.Enemy=null;
        GameManager.Instance.UnitSpawn=null;
        GameManager.Instance.Canon=null;
        GameManager.Instance.aimArea=null;
        GameManager.Instance.isTimeStop=false;

        SceneManager.LoadScene("StartScene");
    }
    
    private void Restart()
    {
        GameManager.Instance.playerList.Clear();
        GameManager.Instance.enemyList.Clear();
        GameManager.Instance.Player=null;
        GameManager.Instance.Enemy=null;
        GameManager.Instance.UnitSpawn=null;
        GameManager.Instance.Canon=null;
        GameManager.Instance.aimArea=null;
        GameManager.Instance.isTimeStop=false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale =1f;
    }

    protected override void Move(RaycastHit2D[] hit)
    {
        throw new System.NotImplementedException();
    }
}