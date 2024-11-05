using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeStoptrigger : MonoBehaviour
{
    public TextMeshProUGUI timer;
    private int min;
    private float sec;
    private float stopTimer = 10;
    private float milliSec;

    private void OnEnable()
    {
        StartCoroutine(BreakStop());
    }

    private void Update()
    {
        stopTimer -=Time.deltaTime;
        sec = (int)stopTimer;
        milliSec =(int)((stopTimer -sec)*100);
        timer.text = $"{sec}:{milliSec}";
    }
    IEnumerator BreakStop()
    {
        GameManager.Instance.isTimeStop = true;
        foreach (EnemyUnit enemy in GameManager.Instance.enemyList)
        {
            enemy.GetComponent<EnemyUnit>().MoveSpeed=0;
        }
        yield return new WaitForSeconds(10);
        foreach (EnemyUnit enemy in GameManager.Instance.enemyList)
        {
            enemy.GetComponent<EnemyUnit>().ResetSpeed();
        }
        gameObject.SetActive(false);
    }

}
