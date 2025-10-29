using UnityEngine;

public class GemMagnet : MonoBehaviour
{
    private Transform playerTransform;

    void Start()
    {
        playerTransform = GetComponentInParent<PlayerHealth>().transform;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gem"))
        {
            Gem gemScript = other.GetComponent<Gem>();

            if (gemScript != null)
            {
                gemScript.StartFollowing(playerTransform);
            }
        }
    }
}