using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawn : MonoBehaviour
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

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);

            for (int i = 0; i < spawnAmount; i++)
            {
                int randEnemy=Random.Range(0, enemyType);
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
            
        }
    }
}
