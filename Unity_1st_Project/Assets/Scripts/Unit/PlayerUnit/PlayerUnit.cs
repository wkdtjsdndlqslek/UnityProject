using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : Unit
{

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
            transform.position += Vector3.left*MoveSpeed*Time.deltaTime;
        }

        else
        {
            Attack(attackList);
        }
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if (hp<maxHp*knockBackHpRatio)
        {
            StartCoroutine(KnockBack());
        }
    }

    public void AccessKnockBack()
    {
        StartCoroutine(KnockBack());
    }

    IEnumerator KnockBack()
    {
        transform.position += Vector3.right*knockBackDistance*Time.deltaTime;
        yield return new WaitForSeconds(1f);
    }

    protected override void Die()
    {
        GameManager.Instance.playerList.Remove(this);
        Destroy(gameObject);
    }
}
