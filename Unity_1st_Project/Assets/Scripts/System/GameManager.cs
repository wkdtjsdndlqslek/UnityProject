using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance=>instance;

    public Player Player{get;set;}
    public List<EnemyUnit> enemyList = new List<EnemyUnit>();
    public List<PlayerUnit> playerList= new List<PlayerUnit>();
    public float sec = 0;
    public int min = 0;
    public float monkeyCooltime = 1;
    public float penguinCooltime = 2;
    public float parrotCooltime = 3;
    public float hippoCooltime = 4;
    public float giraffeCooltime = 5;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(this);
            return;
        }
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

    IEnumerator coolTimeCalculate()
    {
        yield return new WaitForSeconds(giraffeCooltime);
    }
}
