using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlyerUnitSpawn : MonoBehaviour
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
    public Transform spawnPos;

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
        if (GameManager.Instance.Player.resources>=50)
        { 
            Instantiate(monkey,spawnPos);
            GameManager.Instance.Player.resources-=50;
        }
    }

    private void SpawnPenguin()
    {
        if (GameManager.Instance.Player.resources>=200)
        {
            Instantiate(penguin, spawnPos);
            GameManager.Instance.Player.resources-=200;
        }
    }

    private void SpawnParrot()
    {
        if (GameManager.Instance.Player.resources>=350)
        {
            Instantiate(parrot, spawnPos);
            GameManager.Instance.Player.resources-=350;
        }
    }

    private void SpawnHippo()
    {
        if (GameManager.Instance.Player.resources>=1500)
        {
            Instantiate(hippo, spawnPos);
            GameManager.Instance.Player.resources-=1500;
        }
    }

    private void SpawnGiraffe()
    {
        if (GameManager.Instance.Player.resources>=2700)
        {
            Instantiate(giraffe, spawnPos);
            GameManager.Instance.Player.resources-=2700;
        }
    }
}
