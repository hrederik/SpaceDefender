using System.Collections;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
	[SerializeField] private Asteroid _asteroidPrefab;
	[SerializeField] private Transform _target;
	[SerializeField] private Scores _scores;
	[SerializeField] private IndicatorBuilder _indicatorBuilder;
	[SerializeField] private Color _indicatorColor;
	[SerializeField] private float _spawnAreaRadius = 250.0f;
	[SerializeField] private float _generateRate = 5.0f;
	[SerializeField] private float _variance = 1.0f;
	private Coroutine _generating;

	private void Start()
	{
		StartGenerating();
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.white;
		Gizmos.matrix = transform.localToWorldMatrix;
		Gizmos.DrawWireSphere(Vector3.zero, _spawnAreaRadius);
	}

	public void StartGenerating()
	{
		_generating = StartCoroutine(Generating());
	}

	public void StopGenerating()
	{
		StopCoroutine(_generating);
	}

	private IEnumerator Generating()
	{
		float nextSpawnTime;

		while (true)
		{
			nextSpawnTime = _generateRate + Random.Range(-_variance, _variance);
			yield return new WaitForSeconds(nextSpawnTime);
			GenerateAsteroid();
		}
	}

	private void GenerateAsteroid()
	{		
		Asteroid asteroid = Instantiate(_asteroidPrefab, GetGeneratePoint(), Quaternion.identity);
		asteroid.SetTarget(_target);
		asteroid.SetScores(_scores);

		Indicator indicator = _indicatorBuilder.Create()
			.SetOwner(asteroid.transform)
			.SetTarget(_target)
			.SetColor(_indicatorColor)
			.Build();

		asteroid.SetIndicator(indicator);
	}

	private Vector3 GetGeneratePoint()
	{
		Vector3 generatePoint = Random.onUnitSphere * _spawnAreaRadius;
		generatePoint.Scale(transform.lossyScale);

		return generatePoint;
	}
}