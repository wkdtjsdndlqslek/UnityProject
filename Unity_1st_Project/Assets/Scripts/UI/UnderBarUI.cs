using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnderBarUI : MonoBehaviour
{
    public Image monkeyCooltimePanel;
    public GameObject monkeyLackResourcePanel;
    public Image penguinCooltimePanel;
    public GameObject penguinLackResourcePanel;
    public Image parrotCooltimePanel;
    public GameObject parrotLackResourcePanel;
    public Image hippoCooltimePanel;
    public GameObject hippoLackResourcePanel;
    public Image giraffeCooltimePanel;
    public GameObject giraffeLackResourcePanel;
    public Image canonCooltimePanel;

    private void Update()
    {
        ResourceCheck();
        CooltimeCheck();
    }

    private void CooltimeCheck()
    {
        monkeyCooltimePanel.fillAmount = (GameManager.Instance.UnitSpawner.MonkeyCooltime-(Time.time -GameManager.Instance.UnitSpawner.StartMonkeyCooltime))/(GameManager.Instance.UnitSpawner.MonkeyCooltime);
        penguinCooltimePanel.fillAmount =(GameManager.Instance.UnitSpawner.PenguinCooltime-(Time.time -GameManager.Instance.UnitSpawner.StartPenguinCooltime))/(GameManager.Instance.UnitSpawner.PenguinCooltime);
        parrotCooltimePanel.fillAmount =(GameManager.Instance.UnitSpawner.ParrotCooltime -(Time.time - GameManager.Instance.UnitSpawner.StartParrotCooltime))/(GameManager.Instance.UnitSpawner.ParrotCooltime);
        hippoCooltimePanel.fillAmount =(GameManager.Instance.UnitSpawner.HippoCooltime -(Time.time - GameManager.Instance.UnitSpawner.StartHippoCooltime))/(GameManager.Instance.UnitSpawner.HippoCooltime);
        giraffeCooltimePanel.fillAmount =(GameManager.Instance.UnitSpawner.GiraffeCooltime -(Time.time - GameManager.Instance.UnitSpawner.StartGiraffeCooltime))/(GameManager.Instance.UnitSpawner.GiraffeCooltime);
        canonCooltimePanel.fillAmount = (GameManager.Instance.Canon.CanonCooltime-(Time.time- GameManager.Instance.Canon.StartCanonCooltime))/GameManager.Instance.Canon.CanonCooltime;
    }

    private void ResourceCheck()
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
}
