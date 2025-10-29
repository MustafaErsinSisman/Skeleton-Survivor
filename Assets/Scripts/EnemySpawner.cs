using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject enemyPreFab;
    [SerializeField] private float spawnTime = 1.5f;
    [SerializeField] private float spawnDistance = 20f;

    [Header("References")]
    [SerializeField] private Transform playerTransform;

    void Start()
    {
        if (playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
        StartCoroutine(SpawnEnemyRoutine());
    }

    private IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);

            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            Vector3 spawnPos = new Vector3(randomDirection.x, 0, randomDirection.y) * spawnDistance;

            spawnPos += playerTransform.position;
            spawnPos.y = 0.5f;

            NavMeshHit hit;
            if (NavMesh.SamplePosition(spawnPos, out hit, 5.0f, NavMesh.AllAreas))
            {
                Instantiate(enemyPreFab, hit.position, Quaternion.identity);
            }
        }
    }
}