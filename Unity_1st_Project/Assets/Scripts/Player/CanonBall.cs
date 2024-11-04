using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonBall : MonoBehaviour
{
    public float damage = 10f;
    public float moveSpeed = 5;
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
        collision.CompareTag("Land");
        Destroy(gameObject);
    }
}
