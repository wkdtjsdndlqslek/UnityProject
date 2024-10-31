using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSpawn : MonoBehaviour
{
    public Button monkeySpawn;
    public Button parrotSpawn;
    public Button penguinSpawn;
    public Button hippoSpawn;
    public Button giraffeSpawn;
    public GameObject monkey;
    public GameObject parrot;
    public GameObject penguin;
    public GameObject hippo;
    public GameObject giraffe;

    private void Update()
    {
        monkeySpawn.onClick.AddListener(SpawnMonkey);
    }

    private void SpawnMonkey()
    {
        
    }

    private void SpawnParrot()
    {
    }

    private void SpawnPenguin()
    {
    }

    private void SpawnHippo()
    {
    }

    private void SpawnGiraffe()
    {
    }
}
