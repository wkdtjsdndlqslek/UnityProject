using System.Collections;
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
        transform.position += -Vector3.right*knockBackDistance*Time.deltaTime;
        yield return new WaitForSeconds(1f);
    }

    protected override void Die()
    {
        GameManager.Instance.enemyList.Remove(this);
        GameManager.Instance.Player.resources+=unitPrice;
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
            StartCoroutine(HurricaneKnockBack());
        }
    }

    IEnumerator HurricaneKnockBack()
    {
        transform.position += -Vector3.right*moveSpeed*Time.deltaTime;
        transform.position += -Vector3.right*moveSpeed*Time.deltaTime;
        yield return new WaitForSeconds(0.2f);
    }
}
