using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float damage = 2f;
    [SerializeField] private float attackRate = 1f;

    private float nextAttackTime;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Time.time >= nextAttackTime)
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);

                nextAttackTime = Time.time + (1f / attackRate);
            }
        }
    }
}