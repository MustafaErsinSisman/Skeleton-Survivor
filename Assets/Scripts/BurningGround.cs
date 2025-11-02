using System.Collections.Generic; // List<> için ŞART!
using UnityEngine;

public class BurningGround : MonoBehaviour
{
    [Header("Ayarlar")]
    [SerializeField] private float damage = 2f;
    [SerializeField] private float damageRate = 2f;
    [SerializeField] private float lifetime = 3f;

    private float nextDamageTime;
    private List<EnemyHealth> enemiesInZone = new List<EnemyHealth>();

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        if (Time.time < nextDamageTime)
        {
            return;
        }

        nextDamageTime = Time.time + (1f / damageRate);

        for (int i = enemiesInZone.Count - 1; i >= 0; i--)
        {
            if (enemiesInZone[i] != null)
            {
                enemiesInZone[i].TakeDamage(damage);
            }
            else
            {
                enemiesInZone.RemoveAt(i);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth health = other.GetComponent<EnemyHealth>();
            if (health != null && !enemiesInZone.Contains(health))
            {
                enemiesInZone.Add(health);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth health = other.GetComponent<EnemyHealth>();
            if (health != null && enemiesInZone.Contains(health))
            {
                enemiesInZone.Remove(health);
            }
        }
    }
}