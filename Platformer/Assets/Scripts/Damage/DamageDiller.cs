using UnityEngine;

public class DamageDiller : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Health>())
        {
            collision.GetComponent<Health>().TakeDamage(damage);

            Destroy(gameObject);
        }
    }
}
