using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiraffeUnit : MonoBehaviour
{
    public float moveSpeed=0.5f;
    public float hp=6000;
    public int damage=2000;
    public float attackSpeed = 3;
    public int unitPrice = 2700;
    public float range = 5;

    private void Start()
    {
        
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x-1,transform.position.y), -transform.right, range);
        Debug.DrawRay(new Vector2(transform.position.x-1, transform.position.y), -transform.right*range,Color.red);
        if (!hit||!hit.collider.gameObject.CompareTag("Enemy"))
        {
            transform.position += Vector3.left*moveSpeed*Time.deltaTime;
        }
    }

    private void Attack()
    {

    }

    
}
