using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    protected float moveSpeed;
    protected float hp;
    protected int damage;
    protected float attackSpeed;
    protected int unitPrice;
    protected float range;
    protected string camp;
    protected string enemyCamp;
    protected bool isAttack;

    protected virtual void Update()
    {
        isAttack = false;
        RaycastHit2D[] hit = Physics2D.RaycastAll(new Vector2(transform.position.x, transform.position.y), -transform.right, range);
        
        Move(hit, enemyCamp);
    }

    protected virtual void Move(RaycastHit2D[] hit,string enemy)
    {
        for (int i = 0; i < hit.Length; i++)
        {
            if (hit[i].collider.CompareTag(enemyCamp))
            {
                isAttack=true; break;
            }
        }

        if (!isAttack)
        {
            transform.position += Vector3.left*moveSpeed*Time.deltaTime;
        }
        else
        {
            Attack(hit,enemy);
        }
    }

    protected void Attack(RaycastHit2D[] hit,string enemy)
    {
    }

    public void TakeDamage(int onHitDamage)
    {
        hp-=onHitDamage;
    }
}
