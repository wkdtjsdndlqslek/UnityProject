using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : SingletonManager<GameManager>
{
    public Player Player{get;set;}
    public Enemy Enemy{get;set;}
    public UnitSpawn UnitSpawn{get;set;}
    public List<EnemyUnit> enemyList = new List<EnemyUnit>();
    public List<PlayerUnit> playerList= new List<PlayerUnit>();
    public Canon Canon{get;set;}
    public float sec = 0;
    public int min = 0;
    public Transform aimArea;
    public bool isTimeStop=false;
    public GameObject defeatPanel;
    public Button defeatLobby;
    public Button restart;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        sec += Time.deltaTime;
        if (sec>=60f)
        {
            sec = 0;
            min++;
        }
    }

    public void timeClear()
    {
        GameManager.Instance.sec = 0;
        GameManager.Instance.min = 0;
    }

}
