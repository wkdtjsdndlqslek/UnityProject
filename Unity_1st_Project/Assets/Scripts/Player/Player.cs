using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Player : Unit
{
    public float farmingAmount = 20f;
    public float farmingDuration = 3f;
    public float resources = 0f;
    public float maxResources = 1000f;
    public float ResourcesFillAmount { get { return resources/maxResources; } }
    public int level = 1;
    public Button levelUp;
    public int cash = 0;
    public int _hp = 3000;
    public TextMeshProUGUI hpText;
    public int skillDamage;
    public int levelUpPrice = 180;

    protected override void Awake()
    {
        hp =_hp;
        base.Awake();
    }
    private void Start()
    {
        levelUp.onClick.AddListener(LevelUp);
        GameManager.Instance.Player = this;
        StartCoroutine(Farming());
    }

    protected override void Update()
    {
        hpText.text = $"{hp}/{maxHp}";
        fillImage.fillAmount = HpFillAmount;
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

    protected override void Die()
    {
        Time.timeScale =0f;

    }

    protected override void Move(RaycastHit2D[] hit)
    {
        throw new System.NotImplementedException();
    }
}