using System.Collections.Generic;
using UnityEngine;

public class WeaponAura : MonoBehaviour
{
    [SerializeField] private float damage = 5f;
    [SerializeField] private float damageRate = 1f;

    private float nextDamageTime;

    private List<EnemyHealth> enemiesInAura = new List<EnemyHealth>();

    private void Update()
    {
        if (Time.time < nextDamageTime)
        {
            return;
        }

        nextDamageTime = Time.time + (1f / damageRate);

        for (int i = enemiesInAura.Count - 1; i >= 0; i--)
        {
            if (enemiesInAura[i] != null)
            {
                enemiesInAura[i].TakeDamage(damage);
            }
            else
            {
                enemiesInAura.RemoveAt(i);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth health = other.GetComponent<EnemyHealth>();

            if (health != null && !enemiesInAura.Contains(health))
            {
                enemiesInAura.Add(health);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth health = other.GetComponent<EnemyHealth>();

            if (health != null && enemiesInAura.Contains(health))
            {
                enemiesInAura.Remove(health);
            }
        }
    }
}