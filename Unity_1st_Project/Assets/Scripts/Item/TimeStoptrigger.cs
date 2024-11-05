using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeStoptrigger : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(BreakStop());
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
