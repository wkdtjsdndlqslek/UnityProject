using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlyerUnitSpawn : MonoBehaviour
{
    public Button monkeySpawn;
    public GameObject monkey;
    public float monkeyCooltime = 1;
    public Button penguinSpawn;
    public GameObject penguin;
    public float penguinCooltime = 2;
    public Button parrotSpawn;
    public GameObject parrot;
    public float parrotCooltime = 3;
    public Button hippoSpawn;
    public GameObject hippo;
    public float hippoCooltime = 4;
    public Button giraffeSpawn;
    public GameObject giraffe;
    public float giraffeCooltime = 5;
    public Transform spawnPos;
    public GameObject monkeyCooltimePanel;
    public GameObject penguinCooltimePanel;
    public GameObject parrotCooltimePanel;
    public GameObject hippoCooltimePanel;
    public GameObject giraffeCooltimePanel;
    private float endMonkeyCooltime=0;
    private float endPenguinCooltime=0;
    private float endParrotCooltime=0;
    private float endHippoCooltime=0;
    private float endGiraffeCooltime=0;

    private void Start()
    {
        monkeySpawn.onClick.AddListener(SpawnMonkey);
        penguinSpawn.onClick.AddListener(SpawnPenguin);
        parrotSpawn.onClick.AddListener(SpawnParrot);
        hippoSpawn.onClick.AddListener(SpawnHippo);
        giraffeSpawn.onClick.AddListener(SpawnGiraffe);
    }

    private void Update()
    {
        cooltimeCheck();
    }

    private void cooltimeCheck()
    {
        if (endMonkeyCooltime < Time.time && GameManager.Instance.Player.resources>=50) monkeyCooltimePanel.SetActive(false);
        if (endPenguinCooltime < Time.time && GameManager.Instance.Player.resources>=200) penguinCooltimePanel.SetActive(false);
        if (endParrotCooltime < Time.time && GameManager.Instance.Player.resources>=350) parrotCooltimePanel.SetActive(false);
        if (endHippoCooltime < Time.time && GameManager.Instance.Player.resources>=1500) hippoCooltimePanel.SetActive(false);
        if (endGiraffeCooltime < Time.time && GameManager.Instance.Player.resources >= 2700) giraffeCooltimePanel.SetActive(false);

        if (endMonkeyCooltime > Time.time || GameManager.Instance.Player.resources < 50) monkeyCooltimePanel.SetActive(true);
        if (endPenguinCooltime > Time.time || GameManager.Instance.Player.resources < 200) penguinCooltimePanel.SetActive(true);
        if (endParrotCooltime > Time.time || GameManager.Instance.Player.resources < 350) parrotCooltimePanel.SetActive(true);
        if (endHippoCooltime > Time.time || GameManager.Instance.Player.resources < 1500) hippoCooltimePanel.SetActive(true);
        if (endGiraffeCooltime > Time.time || GameManager.Instance.Player.resources < 2700) giraffeCooltimePanel.SetActive(true);
    }

    private void SpawnMonkey()
    {
        if (endMonkeyCooltime < Time.time && GameManager.Instance.Player.resources>=50)
        {
            Instantiate(monkey, spawnPos);
            GameManager.Instance.Player.resources-=50;
            endMonkeyCooltime = Time.time+monkeyCooltime;
        }
        else { return; }
    }

    private void SpawnPenguin()
    {
        if (endPenguinCooltime < Time.time && GameManager.Instance.Player.resources>=200)
        {
            Instantiate(penguin, spawnPos);
            GameManager.Instance.Player.resources-=200;
            endPenguinCooltime = Time.time+penguinCooltime;
        }
        else { return; }
    }

    private void SpawnParrot()
    {
        if (endParrotCooltime < Time.time && GameManager.Instance.Player.resources>=350)
        {
            Instantiate(parrot, spawnPos);
            GameManager.Instance.Player.resources-=350;
            endParrotCooltime = Time.time+parrotCooltime;
        }
        else { return; }
    }

    private void SpawnHippo()
    {
        if (endHippoCooltime < Time.time && GameManager.Instance.Player.resources>=1500)
        {
            Instantiate(hippo, spawnPos);
            GameManager.Instance.Player.resources-=1500;
            endHippoCooltime = Time.time+hippoCooltime;
        }
        else { return; }
    }

    private void SpawnGiraffe()
    {
        if (endGiraffeCooltime < Time.time && GameManager.Instance.Player.resources>=2700)
        {
            Instantiate(giraffe, spawnPos);
            GameManager.Instance.Player.resources-=2700;
            endGiraffeCooltime = Time.time+giraffeCooltime;
        }
        else { return; }
    }
}
