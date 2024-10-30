using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float farmingAmount=180;
    public float farmingDuration=3;
    public float resources;
    public int level;
    public int cash;
    public int hp;
    public int skillDamage;

    private void Start()
    {
        GameManager.Instance.player = this;
        StartCoroutine(Farming());
    }
    
    private void Update()
    {
        
    }

    IEnumerator Farming()
    {
        resources += farmingAmount;
        yield return new WaitForSeconds(farmingDuration);
    }
}
