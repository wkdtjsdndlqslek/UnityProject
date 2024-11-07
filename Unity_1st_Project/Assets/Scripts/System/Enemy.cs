using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.UI.Button;

public class Enemy : Unit
{
    public Transform EnemySpawnPos;
    public float spawnDelay=2f;
    public float spawnAmount=2f;
    public ElephantUnit elephantUnit;
    public PandatUnit pandaUnit;
    public SnakeUnit snakeUnit;
    public PigUnit pigUnit;
    public RabbitUnit rabbitUnit;
    private int enemyType=2;
    public int _hp =9000;
    public TextMeshProUGUI hpText;
    public Coroutine coSpawn;
    public GameObject clearPanel;
    public Button clearLobby;

    protected override void Awake()
    {
        hp=_hp;
        base.Awake();
        knockBackDistance = 0f;
        knockBackHpRatio = 0f;
    }

    private void Start()
    {
        GameManager.Instance.Enemy=this;
        StartSpawnEnemy();
    }

    public void StartSpawnEnemy()
    {
        coSpawn=StartCoroutine(SpawnEnemy());
    }
    
    protected override void Update()
    {
        fillImage.fillAmount = HpFillAmount;
        hpText.text = $"{hp}/{maxHp}";
    }

    public IEnumerator SpawnEnemy()
    {
        while (true)
        {
            if (GameManager.Instance.isTimeStop==false)
            {
                for (int i = 0; i < spawnAmount; i++)
                {
                    int randEnemy = Random.Range(0, enemyType);
                    switch (randEnemy)
                    {
                        case 0:
                            Instantiate(rabbitUnit, EnemySpawnPos);
                            break;
                        case 1:
                            Instantiate(pigUnit, EnemySpawnPos);
                            break;
                        case 2:
                            Instantiate(snakeUnit, EnemySpawnPos);
                            break;
                        case 3:
                            Instantiate(pandaUnit, EnemySpawnPos);
                            break;
                        case 4:
                            Instantiate(elephantUnit, EnemySpawnPos);
                            break;
                    }
                }

                if (GameManager.Instance.min>=4f)
                {
                    enemyType = 5;
                }

                else if (GameManager.Instance.min>=1f)
                {
                    enemyType = 3;
                }
                yield return new WaitForSeconds(spawnDelay);
            }
            else
            {
                yield return new WaitForSeconds(10f);
                GameManager.Instance.isTimeStop = false;
            }
        }
    }

    protected override void Die()
    {
        Time.timeScale = 0f;
        clearPanel.SetActive(true);
        clearLobby.onClick.AddListener(Lobby);
    }

    private void Lobby()
    {
        GameManager.Instance.playerList.Clear();
        GameManager.Instance.enemyList.Clear();
        GameManager.Instance.Player=null;
        GameManager.Instance.Enemy=null;
        GameManager.Instance.UnitSpawn=null;
        GameManager.Instance.Canon=null;
        GameManager.Instance.sec=0;
        GameManager.Instance.min=0;
        GameManager.Instance.aimArea=null;
        GameManager.Instance.isTimeStop=false;

        SceneManager.LoadScene("StartScene");
    }

    protected override void Move(RaycastHit2D[] hit)
    {
        throw new System.NotImplementedException();
    }
}

