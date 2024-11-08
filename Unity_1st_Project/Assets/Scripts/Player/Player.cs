using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int farmingAmount = 20;
    public float farmingDuration = 3f;
    public float resources = 0f;
    public float maxResources = 1000f;
    public float ResourcesFillAmount { get { return resources/maxResources; } }
    public int level = 1;
    public int cash = 1000;
    public int skillDamage;
    public int levelUpPrice = 180;
    public Button playerTowerLevelUp;
    public TextMeshProUGUI levelUpText;
    public TextMeshProUGUI levelUpPriceText;
    public GameObject levelUpCooltime;
    public Slider currentResource;
    public TextMeshProUGUI resourcesPercent;

    private void Start()
    {
        playerTowerLevelUp.onClick.AddListener(LevelUp);
        GameManager.Instance.Player=this;
        StartCoroutine(FarmingResource());
    }

    private void Update()
    {
        levelUpText.text = $"Lv. {level} LEVEL UP! ";
        currentResource.value = ResourcesFillAmount;
        resourcesPercent.text = $"{resources} / {maxResources}";
        levelUpPriceText.text =$"{levelUpPrice}";
        if (level==8)
        {
            levelUpPrice=0;
            levelUpPriceText.text="MAX";
        }
        if (levelUpPrice>resources)
        {
            levelUpCooltime.SetActive(true);
        }
        else
        {
            levelUpCooltime.SetActive(false);
        }
    }

    IEnumerator FarmingResource()
    {
        while (true)
        {
            yield return new WaitForSeconds(farmingDuration);
            EarnResoure(farmingAmount);
        }
    }

    public void EarnResoure(int gainResource)
    {
        if (resources<maxResources)
        {
            resources += gainResource;
        }
        else if (resources+gainResource>maxResources)
        {
            resources = maxResources;
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
}
