using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : SingletonManager<GameManager>
{
    public Player Player{get;set;}
    public PlayerTower PlayerTower{get;set;}
    public EnemyTower EnemyTower{get;set;}
    public UnitSpawner UnitSpawner{get;set;}
    public List<EnemyUnit> enemyList = new List<EnemyUnit>();
    public List<PlayerUnit> playerList= new List<PlayerUnit>();
    public Canon Canon{get;set;}
    public float sec = 0;
    public int min = 0;
    public Transform aimArea;
    public bool isTimeStop=false;

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

    public void Reset()
    {
        playerList.Clear();
        enemyList.Clear();
        Player=null;
        EnemyTower=null;
        UnitSpawner=null;
        Canon=null;
        aimArea=null;
        isTimeStop=false;
    }
}
