using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEditor;
using UnityEngine;

public class CanonBall : MonoBehaviour
{
    public int damage = 2000;
    public float moveSpeed = 5;
    public float explosionRange = 2f;
    public GameObject explosion;

    CircleCollider2D circleCollider;
    private void Start()
    {
    }
    private void Update()
    {
        Move(Vector2.up);
    }

    private void Move(Vector2 dir)
    {
        transform.Translate(dir*moveSpeed*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Land"))
        {
            Instantiate(explosion,transform.position,Quaternion.identity);
            RaycastHit2D[] hit2Ds = Physics2D.CircleCastAll(transform.position, explosionRange, Vector2.zero);

            Vector2[] coordination = new Vector2[360];
            for(int i = 0; i<360; i++)
            {
                coordination[i]=new Vector2(Mathf.Cos(i),Mathf.Sin(i))*explosionRange;
                if (i<359)
                {
                Debug.DrawLine(coordination[i]+(Vector2)transform.position, coordination[i+1]+(Vector2)transform.position);
                }
            }
            foreach (RaycastHit2D hit2d in hit2Ds)
            {
                if(hit2d.collider.CompareTag("Enemy"))
                {
                    hit2d.collider.GetComponent<EnemyUnit>().TakeDamage(damage);
                }
            }

            Destroy(gameObject);
        }
        
    }
}
