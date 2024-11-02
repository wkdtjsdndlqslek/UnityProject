using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float farmingAmount=20f;
    public float farmingDuration=3f;
    public float resources=0f;
    public float maxResources=1000f;
    public float ResourcesFillAmount { get {  return resources/maxResources; } }
    public int level=1;
    public int cash=0;
    public int hp = 3000;
    private int maxHp;
    public int skillDamage;
    public Button levelUp;
    public TextMeshProUGUI levelUptext;
    public int levelUpPrice=180;

    private void Awake()
    {
        maxHp=hp;
    }

    private void Start()
    {
        levelUp.onClick.AddListener(LevelUp);
        GameManager.Instance.Player = this;
        StartCoroutine(Farming());
    }

    private void Update()
    {
        levelUptext.text = $"Lv. {level} LEVEL UP! ";
    }

    IEnumerator Farming()
    {
        while (true)
        {
            yield return new WaitForSeconds(farmingDuration);
            if (resources<maxResources)
            {
                resources += farmingAmount;
            }
            else if (resources+maxResources>maxResources)
            {
                resources = maxResources;
            }
        }
    }

    private void LevelUp()
    {

        print("ghcnf");
        if (level==8)
        { }
        else if (resources>levelUpPrice)
        {
            resources -= levelUpPrice;
            maxResources+=500;
            farmingAmount +=20;
            levelUpPrice+=180;
            level++;
        }
    }

}
