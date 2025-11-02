using UnityEngine;

public class ArrowProjectile : MonoBehaviour
{
	[Header("Settings")]
	[SerializeField] private float speed = 25f;
	[SerializeField] private float damage = 15f;
	private Transform target;

	public void SetTarget(Transform newTarget)
	{
		target = newTarget;
	}

	void Update()
	{
		if (target == null)
		{
			Destroy(gameObject);
			return;
		}

		transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

		transform.LookAt(target.position);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy"))
		{
			EnemyHealth health = other.GetComponent<EnemyHealth>();
			if (health != null)
			{
				health.TakeDamage(damage);
			}
			Destroy(gameObject);
		}
	}
}