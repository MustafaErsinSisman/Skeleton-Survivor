using UnityEngine;
using System.Collections;

public class MeteorController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject meteorPrefab;
    [SerializeField] private float fireRate = 5f;
    [SerializeField] private float spawnHeight = 15f;

    void Start()
    {
        InvokeRepeating("Fire", 0f, fireRate);
    }

    void Fire()
    {
        Transform randomEnemy = FindRandomEnemy();

        if (randomEnemy != null)
        {
            Vector3 spawnPosition = new Vector3(
                randomEnemy.position.x,
                spawnHeight,
                randomEnemy.position.z
            );
            Instantiate(meteorPrefab, spawnPosition, Quaternion.identity);
        }
    }
    private Transform FindRandomEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length == 0)
        {
            return null;
        }
        int randomIndex = Random.Range(0, enemies.Length);
        
        return enemies[randomIndex].transform;
    }
}