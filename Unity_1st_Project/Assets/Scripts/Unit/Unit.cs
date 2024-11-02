using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Unit : MonoBehaviour
{
    protected float moveSpeed;
    protected float hp;
    protected float maxHp;
    protected int damage;
    protected int unitPrice;
    protected float attackRange;
    protected string camp;
    protected string enemyCamp;
    protected bool isAttack;
    protected float preDamageTime;
    protected float attackInteval=1;
    public Image fillImage;
    protected bool isAreaAttack;
    protected float HpFillAmount { get { return hp/maxHp; } }
    protected List<RaycastHit2D> attackList = new List<RaycastHit2D>();

    protected virtual void Awake()
    {
        maxHp=hp;
    }

    protected virtual void Update()
    {
        fillImage.fillAmount = HpFillAmount;
        isAttack = false;
        RaycastHit2D[] hit = Physics2D.RaycastAll(new Vector2(transform.position.x, transform.position.y), -transform.right, attackRange);
        
        Move(hit);
    }

    protected void Attack(List<RaycastHit2D> attackList)
    {
        if (preDamageTime+attackInteval<Time.time)
        {
            if (isAreaAttack)
            {
                foreach (var attack in attackList)
                {
                    attack.collider.GetComponent<Unit>().TakeDamage(damage);
                }
            }
            else
            {
                attackList[0].collider.GetComponent<Unit>().TakeDamage(damage);
            }
        }

        else
        {
            return;
        }

        preDamageTime = Time.time+attackInteval;
    }

    public void TakeDamage(int onHitDamage)
    {
        print($"{gameObject.name},{onHitDamage}");
        hp-=onHitDamage;
        if(hp <= 0)
        {
            Die();
        }
    }

    protected abstract void Move(RaycastHit2D[] hit);

    protected abstract void Die();
}
