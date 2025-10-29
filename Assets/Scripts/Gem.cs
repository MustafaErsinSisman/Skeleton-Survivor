using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] private int xpValue = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (LevelManager.Instance != null)
            {
                LevelManager.Instance.AddXP(xpValue);
            }
            Destroy(gameObject);
        }
    }
}