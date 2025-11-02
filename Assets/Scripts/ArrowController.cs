using UnityEngine;
using System.Collections;

public class ArrowController : MonoBehaviour
{
	[Header("Settings")]
	[SerializeField] private GameObject arrowPrefab;
	[SerializeField] private float fireRate = 2f;
	
	private float fireTimer;

	void Start()
	{
		InvokeRepeating("Fire", 0f, fireRate);
	}

	void Fire()
	{
		Transform closestEnemy = FindClosestEnemy();

		if (closestEnemy != null)
		{
			GameObject newArrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);

			ArrowProjectile arrowScript = newArrow.GetComponent<ArrowProjectile>();

			arrowScript.SetTarget(closestEnemy);
		}
	}

	private Transform FindClosestEnemy()
	{
		
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		Transform closest = null;
		float minDistance = Mathf.Infinity;
		Vector3 currentPosition = transform.position;

		foreach (GameObject enemy in enemies)
		{
			float distance = Vector3.Distance(enemy.transform.position, currentPosition);
			if (distance < minDistance)
			{
				minDistance = distance;
				closest = enemy.transform;
			}
		}
		return closest;
	}
}