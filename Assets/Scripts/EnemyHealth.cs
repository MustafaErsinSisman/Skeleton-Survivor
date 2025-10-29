using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 10f;
    [SerializeField] private GameObject gem;
    private float currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

   private void Die()
    {
        if (gem != null)
        {
            Vector3 spawnPosition = transform.position;
            spawnPosition.y = 0.1f; 
            Instantiate(gem, spawnPosition, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}