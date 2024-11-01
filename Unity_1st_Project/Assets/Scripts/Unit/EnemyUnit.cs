using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : Unit
{

    protected override void Awake()
    {
        base.Awake();
        camp = "Enemy";
        enemyCamp = "Player";
        gameObject.tag = camp;
    }

    protected override void Update()
    {
        isAttack = false;
        RaycastHit2D[] hit = Physics2D.RaycastAll(new Vector2(transform.position.x, transform.position.y), transform.right, range);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), transform.right*range, Color.red);

        Move(hit, enemyCamp);
    }

    protected override void Move(RaycastHit2D[] hit, string enemy)
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
            transform.position += Vector3.right*moveSpeed*Time.deltaTime;
        }
        else
        {
            Attack(hit, enemy);
        }
    }

}
