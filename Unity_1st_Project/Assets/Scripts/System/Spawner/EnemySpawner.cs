using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Lean.Pool;

public class EnemySpawner : MonoBehaviour
{
    public float spawnDelay = 2f;
    public float spawnAmount = 2f;
    public ElephantUnit elephantUnit;
    public PandatUnit pandaUnit;
    public SnakeUnit snakeUnit;
    public PigUnit pigUnit;
    public RabbitUnit rabbitUnit;
    private int enemyType = 2;
    private Coroutine Spawn;

    private void Start()
    {
        StartSpawnEnemy();
    }

    public void StartSpawnEnemy()
    {
        Spawn=StartCoroutine(SpawnEnemy());
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
                            LeanPool.Spawn(rabbitUnit,transform);
                            break;
                        case 1:
                            LeanPool.Spawn(pigUnit, transform);
                            break;
                        case 2:
                            LeanPool.Spawn(snakeUnit, transform);
                            break;
                        case 3:
                            LeanPool.Spawn(pandaUnit, transform);
                            break;
                        case 4:
                            LeanPool.Spawn(elephantUnit, transform);
                            break;
                    }
                }

                if (GameManager.Instance.min>=2f)
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
            }
        }
    }
}
