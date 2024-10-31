using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSpawn : MonoBehaviour
{
    public Button monkeySpawn;
    public Button penguinSpawn;
    public Button parrotSpawn;
    public Button hippoSpawn;
    public Button giraffeSpawn;
    public GameObject monkey;
    public GameObject penguin;
    public GameObject parrot;
    public GameObject hippo;
    public GameObject giraffe;

    private void Start()
    {
        monkeySpawn.onClick.AddListener(SpawnMonkey);
        penguinSpawn.onClick.AddListener(SpawnPenguin);
        parrotSpawn.onClick.AddListener(SpawnParrot);
        hippoSpawn.onClick.AddListener(SpawnHippo);
        giraffeSpawn.onClick.AddListener(SpawnGiraffe);
    }

    private void SpawnMonkey()
    {
        if (GameManager.Instance.player.resources>=50)
        {
            Vector3 spawnPos = GameManager.Instance.player.transform.position;
            Instantiate(monkey, spawnPos, Quaternion.identity);
            GameManager.Instance.player.resources-=50;
        }
    }

    private void SpawnPenguin()
    {
        if (GameManager.Instance.player.resources>=200)
        {
            Vector3 spawnPos = GameManager.Instance.player.transform.position;
            Instantiate(penguin, spawnPos, Quaternion.identity);
            GameManager.Instance.player.resources-=200;
        }
    }

    private void SpawnParrot()
    {
        if (GameManager.Instance.player.resources>=350)
        {
            print("È£Ãâ");
            Vector3 spawnPos = GameManager.Instance.player.transform.position;
            Instantiate(parrot, spawnPos, Quaternion.identity);
            GameManager.Instance.player.resources-=350;
        }
    }

    private void SpawnHippo()
    {
        if (GameManager.Instance.player.resources>=1500)
        {
            Vector3 spawnPos = GameManager.Instance.player.transform.position;
            Instantiate(hippo, spawnPos, Quaternion.identity);
            GameManager.Instance.player.resources-=1500;
        }
    }

    private void SpawnGiraffe()
    {
        if (GameManager.Instance.player.resources>=2700)
        {
            Vector3 spawnPos = GameManager.Instance.player.transform.position;
            Instantiate(giraffe, spawnPos, Quaternion.identity);
            GameManager.Instance.player.resources-=2700;
        }
    }
}
