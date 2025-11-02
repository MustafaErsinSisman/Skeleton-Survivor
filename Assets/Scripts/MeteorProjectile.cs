using UnityEngine;

public class MeteorProjectile : MonoBehaviour
{
	[Header("Settings")]
	[SerializeField] private float fallSpeed = 40f;
	[SerializeField] private float impactDamage = 50f;
	[SerializeField] private float impactRadius = 2f;
	[SerializeField] private GameObject burningGroundPrefab;
	
	[Header("Physics Control")]
	[SerializeField] private LayerMask enemyLayer;

	void Update()
	{
	    transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
	}

	private void OnCollisionEnter(Collision collision)
	{
		Vector3 impactPoint = transform.position;

		Collider[] enemiesToDamage = Physics.OverlapSphere(impactPoint, impactRadius, enemyLayer);

		foreach (Collider enemyCollider in enemiesToDamage)
		{
			EnemyHealth health = enemyCollider.GetComponent<EnemyHealth>();
			if (health != null)
			{
				health.TakeDamage(impactDamage);
			}
		}

		if (burningGroundPrefab != null)
		{
			Vector3 groundPosition = new Vector3(impactPoint.x, 0.1f, impactPoint.z);

			Instantiate(burningGroundPrefab, groundPosition, Quaternion.identity);
		}

		Destroy(gameObject);
	}
}