using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSpawn : MonoBehaviour
{
    public Button monkeySpawn;
    public GameObject monkey;
    public float _monkeyCooltime = 1;
    public Button penguinSpawn;
    public GameObject penguin;
    public float _penguinCooltime = 2;
    public Button parrotSpawn;
    public GameObject parrot;
    public float _parrotCooltime = 3;
    public Button hippoSpawn;
    public GameObject hippo;
    public float _hippoCooltime = 4;
    public Button giraffeSpawn;
    public GameObject giraffe;
    public float _giraffeCooltime = 5;
    public Transform spawnPos;
    public Image monkeyCooltimePanel;
    public Image penguinCooltimePanel;
    public Image parrotCooltimePanel;
    public Image hippoCooltimePanel;
    public Image giraffeCooltimePanel;
    public GameObject monkeyLackResourcePanel;
    public GameObject penguinLackResourcePanel;
    public GameObject parrotLackResourcePanel;
    public GameObject hippoLackResourcePanel;
    public GameObject giraffeLackResourcePanel;
    private float monkeyCooltime;
    private float penguinCooltime;
    private float parrotCooltime;
    private float hippoCooltime;
    private float giraffeCooltime;
    private float endMonkeyCooltime=0;
    private float endPenguinCooltime=0;
    private float endParrotCooltime=0;
    private float endHippoCooltime=0;
    private float endGiraffeCooltime=0;
    private float startMonkeyCooltime;
    private float startPenguinCooltime;
    private float startParrotCooltime;
    private float startHippoCooltime;
    private float startGiraffeCooltime;

    private void Awake()
    {
        monkeyCooltime =_monkeyCooltime;
        penguinCooltime =_penguinCooltime;
        parrotCooltime =_parrotCooltime;
        hippoCooltime =_hippoCooltime;
        giraffeCooltime =_giraffeCooltime;
        startMonkeyCooltime =-monkeyCooltime;
        startPenguinCooltime =-penguinCooltime;
        startParrotCooltime =-parrotCooltime;
        startHippoCooltime =-hippoCooltime;
        startGiraffeCooltime =-giraffeCooltime;
    }
    private void Start()
    {
        GameManager.Instance.UnitSpawn=this;
        monkeySpawn.onClick.AddListener(SpawnMonkey);
        penguinSpawn.onClick.AddListener(SpawnPenguin);
        parrotSpawn.onClick.AddListener(SpawnParrot);
        hippoSpawn.onClick.AddListener(SpawnHippo);
        giraffeSpawn.onClick.AddListener(SpawnGiraffe);
    }

    private void Update()
    {
        cooltimeCheck();
        monkeyCooltimePanel.fillAmount = (monkeyCooltime-(Time.time -startMonkeyCooltime))/(monkeyCooltime);
        penguinCooltimePanel.fillAmount =(penguinCooltime-(Time.time -startPenguinCooltime))/(penguinCooltime);
        parrotCooltimePanel.fillAmount =(parrotCooltime -(Time.time - startParrotCooltime))/(parrotCooltime);
        hippoCooltimePanel.fillAmount =(hippoCooltime -(Time.time - startHippoCooltime))/(hippoCooltime);
        giraffeCooltimePanel.fillAmount =(giraffeCooltime -(Time.time - startGiraffeCooltime))/(giraffeCooltime);
    }

    private void cooltimeCheck()
    {
        if (GameManager.Instance.Player.resources>=50) monkeyLackResourcePanel.SetActive(false);
        if (GameManager.Instance.Player.resources>=200) penguinLackResourcePanel.SetActive(false);
        if (GameManager.Instance.Player.resources >= 350) parrotLackResourcePanel.SetActive(false);
        if (GameManager.Instance.Player.resources >= 1500) hippoLackResourcePanel.SetActive(false);
        if (GameManager.Instance.Player.resources >= 2700) giraffeLackResourcePanel.SetActive(false);

        if (GameManager.Instance.Player.resources < 50) monkeyLackResourcePanel.SetActive(true);
        if (GameManager.Instance.Player.resources < 200) penguinLackResourcePanel.SetActive(true);
        if (GameManager.Instance.Player.resources < 350) parrotLackResourcePanel.SetActive(true);
        if (GameManager.Instance.Player.resources < 1500) hippoLackResourcePanel.SetActive(true);
        if (GameManager.Instance.Player.resources < 2700) giraffeLackResourcePanel.SetActive(true);
    }

    private void SpawnMonkey()
    {
        if (endMonkeyCooltime < Time.time && GameManager.Instance.Player.resources>=50)
        {
            Instantiate(monkey, spawnPos);
            GameManager.Instance.Player.resources-=50;
            startMonkeyCooltime = Time.time;
            endMonkeyCooltime = startMonkeyCooltime+monkeyCooltime;
        }
        else { return; }
    }

    private void SpawnPenguin()
    {
        if (endPenguinCooltime < Time.time && GameManager.Instance.Player.resources>=200)
        {
            Instantiate(penguin, spawnPos);
            GameManager.Instance.Player.resources-=200;
            startPenguinCooltime = Time.time;
            endPenguinCooltime = startPenguinCooltime+penguinCooltime;
        }
        else { return; }
    }

    private void SpawnParrot()
    {
        if (endParrotCooltime < Time.time && GameManager.Instance.Player.resources>=350)
        {
            Instantiate(parrot, spawnPos);
            GameManager.Instance.Player.resources-=350;
            startParrotCooltime = Time.time;
            endParrotCooltime =startParrotCooltime+parrotCooltime;
        }
        else { return; }
    }

    private void SpawnHippo()
    {
        if (endHippoCooltime < Time.time && GameManager.Instance.Player.resources>=1500)
        {
            Instantiate(hippo, spawnPos);
            GameManager.Instance.Player.resources-=1500;
            startHippoCooltime = Time.time;
            endHippoCooltime = startHippoCooltime+hippoCooltime;
        }
        else { return; }
    }

    private void SpawnGiraffe()
    {
        if (endGiraffeCooltime < Time.time && GameManager.Instance.Player.resources>=2700)
        {
            Instantiate(giraffe, spawnPos);
            GameManager.Instance.Player.resources-=2700;
            startGiraffeCooltime = Time.time;
            endGiraffeCooltime =startGiraffeCooltime+giraffeCooltime;
        }
        else { return; }
    }

    public void accessNoCool()
    {
        StartCoroutine(NoCool());
    }

    public IEnumerator NoCool()
    {
        monkeyCooltime=0;
        penguinCooltime=0;
        parrotCooltime=0;
        hippoCooltime=0;
        giraffeCooltime=0;
        yield return new WaitForSeconds(10f);
        monkeyCooltime=_monkeyCooltime;
        penguinCooltime=_penguinCooltime;
        parrotCooltime=_parrotCooltime;
        hippoCooltime=_hippoCooltime;
        giraffeCooltime=_giraffeCooltime;
    }
}
