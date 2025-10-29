using UnityEngine;
using UnityEngine.AI;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    private Transform hedef;
    private NavMeshAgent agent;

    [Header("Optimization Settings")]
    [SerializeField] private float pathUpdateRate = 0.2f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        hedef = GameObject.FindGameObjectWithTag("Player").transform;
        agent.avoidancePriority = Random.Range(1, 100);
        if (hedef != null)
        {
            StartCoroutine(UpdatePathRoutine());
        }
    }
    private IEnumerator UpdatePathRoutine()
    {
        while (true)
        {
            if (hedef != null && agent.isOnNavMesh)
            {
                agent.SetDestination(hedef.position);
            }
            yield return new WaitForSeconds(pathUpdateRate);
        }
    }
}