using Lean.Common;
using Lean.Pool;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UnitSpawner : MonoBehaviour
{
    public float _monkeyCooltime = 1;
    public float _penguinCooltime = 2;
    public float _parrotCooltime = 3;
    public float _hippoCooltime = 4;
    public float _giraffeCooltime = 5;
    public GameObject monkey;
    public Button monkeySpawn;
    public GameObject penguin;
    public Button penguinSpawn;
    public GameObject parrot;
    public Button parrotSpawn;
    public GameObject hippo;
    public Button hippoSpawn;
    public GameObject giraffe;
    public Button giraffeSpawn;
    public float MonkeyCooltime { get; set; }
    public float PenguinCooltime { get; set; }
    public float ParrotCooltime { get; set; }
    public float HippoCooltime { get; set; }
    public float GiraffeCooltime { get; set; }
    private float endMonkeyCooltime=0;
    private float endPenguinCooltime=0;
    private float endParrotCooltime=0;
    private float endHippoCooltime=0;
    private float endGiraffeCooltime=0;
    public float StartMonkeyCooltime{ get; set; }
    public float StartPenguinCooltime{ get; set; }
    public float StartParrotCooltime{ get; set; }
    public float StartHippoCooltime{ get; set; }
    public float StartGiraffeCooltime{ get; set; }

    private void Awake()
    {
        MonkeyCooltime =_monkeyCooltime;
        PenguinCooltime =_penguinCooltime;
        ParrotCooltime =_parrotCooltime;
        HippoCooltime =_hippoCooltime;
        GiraffeCooltime =_giraffeCooltime;
        StartMonkeyCooltime =-MonkeyCooltime;
        StartPenguinCooltime =-PenguinCooltime;
        StartParrotCooltime =-ParrotCooltime;
        StartHippoCooltime =-HippoCooltime;
        StartGiraffeCooltime =-GiraffeCooltime;
    }
    private void Start()
    {
        GameManager.Instance.UnitSpawner=this;
        monkeySpawn.onClick.AddListener(SpawnMonkey);
        penguinSpawn.onClick.AddListener(SpawnPenguin);
        parrotSpawn.onClick.AddListener(SpawnParrot);
        hippoSpawn.onClick.AddListener(SpawnHippo);
        giraffeSpawn.onClick.AddListener(SpawnGiraffe);
    }

    private void SpawnMonkey()
    {
        if (endMonkeyCooltime < Time.time && GameManager.Instance.Player.resources>=50)
        {
            LeanPool.Spawn(monkey, transform);
            GameManager.Instance.Player.resources-=50;
            StartMonkeyCooltime = Time.time;
            endMonkeyCooltime = StartMonkeyCooltime+MonkeyCooltime;
        }
        else { return; }
    }

    private void SpawnPenguin()
    {
        if (endPenguinCooltime < Time.time && GameManager.Instance.Player.resources>=200)
        {
            LeanPool.Spawn(penguin,transform);
            GameManager.Instance.Player.resources-=200;
            StartPenguinCooltime = Time.time;
            endPenguinCooltime = StartPenguinCooltime+PenguinCooltime;
        }
        else { return; }
    }

    private void SpawnParrot()
    {
        if (endParrotCooltime < Time.time && GameManager.Instance.Player.resources>=350)
        {
            LeanPool.Spawn(parrot, transform);
            GameManager.Instance.Player.resources-=350;
            StartParrotCooltime = Time.time;
            endParrotCooltime =StartParrotCooltime+ParrotCooltime;
        }
        else { return; }
    }

    private void SpawnHippo()
    {
        if (endHippoCooltime < Time.time && GameManager.Instance.Player.resources>=1500)
        {
            LeanPool.Spawn(hippo, transform);
            GameManager.Instance.Player.resources-=1500;
            StartHippoCooltime = Time.time;
            endHippoCooltime = StartHippoCooltime+HippoCooltime;
        }
        else { return; }
    }

    private void SpawnGiraffe()
    {
        if (endGiraffeCooltime < Time.time && GameManager.Instance.Player.resources>=2700)
        {
            LeanPool.Spawn(giraffe, transform);
            GameManager.Instance.Player.resources-=2700;
            StartGiraffeCooltime = Time.time;
            endGiraffeCooltime =StartGiraffeCooltime+GiraffeCooltime;
        }
        else { return; }
    }

    Coroutine coroutine = null;

    public void accessNoCool()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
        coroutine = StartCoroutine(NoCool());
    }

    public IEnumerator NoCool()
    {
        MonkeyCooltime=0;
        PenguinCooltime=0;
        ParrotCooltime=0;
        HippoCooltime=0;
        GiraffeCooltime=0;
        yield return new WaitForSeconds(10f);
        MonkeyCooltime=_monkeyCooltime;
        PenguinCooltime=_penguinCooltime;
        ParrotCooltime=_parrotCooltime;
        HippoCooltime=_hippoCooltime;
        GiraffeCooltime=_giraffeCooltime;
    }
}
