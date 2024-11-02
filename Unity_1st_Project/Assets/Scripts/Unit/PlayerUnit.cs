using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : Unit
{
    protected bool isCoolTime;
    protected float unitCooltime;

    protected override void Awake()
    {
        base.Awake();
        camp = "Player";
        enemyCamp = "Enemy";
        gameObject.tag = camp;
    }

    protected override void Move(RaycastHit2D[] hit)
    {
        attackList.Clear();
        for (int i = 0; i < hit.Length; i++)
        {
            if (hit[i].collider.CompareTag(enemyCamp))
            {
                attackList.Add(hit[i]);
                isAttack=true;
            }
        }

        if (!isAttack)
        {
            transform.position += Vector3.left*moveSpeed*Time.deltaTime;
        }

        else
        {
            Attack(attackList);
        }
    }

    protected override void Die()
    {
        GameManager.Instance.playerList.Remove(this);
        Destroy(gameObject);
    }
}
