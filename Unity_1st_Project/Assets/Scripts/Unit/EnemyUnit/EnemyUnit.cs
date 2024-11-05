using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyUnit : Unit
{
    public float moveSpeed;
    protected override void Awake()
    {
        base.Awake();
        camp = "Enemy";
        enemyCamp = "Player";
        gameObject.tag = camp;
    }

    protected override void Update()
    {
        fillImage.fillAmount = HpFillAmount;
        isAttack = false;
        RaycastHit2D[] hit = Physics2D.RaycastAll(new Vector2(transform.position.x, transform.position.y), transform.right, attackRange);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), transform.right*attackRange, Color.red);

        Move(hit);
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
            transform.position += Vector3.right*MoveSpeed*Time.deltaTime;
        }

        else
        {
            Attack(attackList);
        }
    }

    protected override void Die()
    {
        GameManager.Instance.enemyList.Remove(this);
        Destroy(gameObject);
    }

    public void ResetSpeed()
    {
        MoveSpeed = moveSpeed;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Hurricane"))
        {
            StartCoroutine(KnockBack());
        }
    }

    IEnumerator KnockBack()
    {
        this.MoveSpeed = -this.MoveSpeed;
        yield return new WaitForSeconds(0.2f);
        this.MoveSpeed = -this.MoveSpeed;
    }
}
