using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    [SerializeField] private float damage = 10f; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth health = other.GetComponent<EnemyHealth>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }
}