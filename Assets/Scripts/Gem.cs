using UnityEngine;

public class Gem : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int xpValue = 1;
    [SerializeField] private float moveSpeed = 15f;

    [Header("Situation")]
    private Transform targetPlayer;
    private bool isFollowing = false;
    private const float COLLECTION_DISTANCE = 0.5f; 
    public void StartFollowing(Transform playerTransform)
    {
        isFollowing = true;
        targetPlayer = playerTransform;
    }

    void Update()
    {
        if (isFollowing && targetPlayer != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPlayer.position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPlayer.position) < COLLECTION_DISTANCE)
            {
                CollectGem();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        if (player != null)
        {
            CollectGem();
        }
    }
    private void CollectGem()
    {
        if (LevelManager.Instance != null)
        {
            LevelManager.Instance.AddXP(xpValue);
        }
        Destroy(gameObject);
    }
}