using Lean.Pool;
using UnityEngine;

public class ThunderAim : MonoBehaviour
{
    public Thunder thunder;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
        transform.position =new Vector3(mousePos.x, transform.position.y, transform.position.z);
        if (transform.position.x<-8)
        {
            transform.position = new Vector3(-8f, transform.position.y);
        }
        else if (transform.position.x>8)
        {
            transform.position = new Vector3(8f, transform.position.y);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    private void Fire()
    {
        LeanPool.Spawn(thunder,transform.position,Quaternion.identity);
        LeanPool.Despawn(gameObject);
    }
}
