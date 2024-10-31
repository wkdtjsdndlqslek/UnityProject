using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance=>instance;

    internal Player player;
    internal List<EnemyUnit> enemyList = new List<EnemyUnit>();
    internal List<PlayerUnit> playerList= new List<PlayerUnit>();

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

}
