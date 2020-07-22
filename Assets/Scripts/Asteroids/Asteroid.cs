using UnityEngine;

public class Asteroid : Damageable
{
	[SerializeField] private Rigidbody _rigidbody;
	[SerializeField] private Damager _damager;
	[SerializeField] private float _speed = 10.0f;
	[SerializeField] private int _damage = 1;
	[SerializeField] private int _scoresForDestraction;
	private Scores _scores;
	private Transform _target;
	private Indicator _indicator;

	private void Start()
	{
		transform.LookAt(_target);
		_rigidbody.velocity = transform.forward * _speed;
	}

	private void OnCollisionEnter(Collision collision)
	{
		_damager.Damage(collision.gameObject, _damage);
	}

	public void SetScores(Scores scores)
	{
		_scores = scores;
	}

	public void SetTarget(Transform target)
	{
		_target = target;
	}

	public void SetIndicator(Indicator indicator)
	{
		_indicator = indicator;
	}

	protected override void OnDamage() { }

	protected override void OnDeath()
	{
		_scores.Increase(_scoresForDestraction);
		_indicator.Destroy();
		Destroy(gameObject);
	}	
}