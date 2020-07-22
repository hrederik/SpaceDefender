using System;
using UnityEngine;

public abstract class Damageable : MonoBehaviour
{
	[SerializeField] private GameObject _destructionPrefab;
	[SerializeField] private float _maxHealth;
	private float _health;
	public event Action<float, float> HealthChanged;

	private void Awake()
	{
		_health = _maxHealth;
		HealthChanged?.Invoke(_health, _maxHealth);
	}

	public void TakeDamage(float amount)
	{
		OnDamage();

		_health -= amount;
		HealthChanged?.Invoke(_health, _maxHealth);
		if (_health <= 0)
		{
			_health = 0;
			Instantiate(_destructionPrefab, transform.position, transform.rotation);
			OnDeath();
		}		
	}

	protected abstract void OnDamage();
	protected abstract void OnDeath();
}