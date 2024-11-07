using UnityEngine;

public class Hurricane : MonoBehaviour
{
    public float moveSpeed =2f;
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        transform.Translate(-Vector2.right*moveSpeed*Time.deltaTime);
        if(transform.position.x<=-8)
        {
            Destroy(gameObject);
        }
    }
}
