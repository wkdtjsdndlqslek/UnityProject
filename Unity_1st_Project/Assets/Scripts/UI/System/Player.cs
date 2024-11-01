using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float farmingAmount=100;
    public float farmingDuration=3f;
    public float resources=0f;
    public float maxResources=1000f;
    public float ResourcesFillAmount { get {  return resources/maxResources; } }
    public int level=1;
    public int cash=0;
    public int hp = 3000;
    public int skillDamage;

    
    private void Start()
    {
        GameManager.Instance.Player = this;
        StartCoroutine(Farming());
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
}
