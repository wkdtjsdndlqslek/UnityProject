using UnityEngine;

public class Thunder : MonoBehaviour
{
    public int damage = 3000;

    private void Update()
    {
        Invoke("Disappear", 1f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyUnit>().TakeDamage(damage);
        }
    }

    private void Disappear()
    {
        Destroy(gameObject);
    }
}
