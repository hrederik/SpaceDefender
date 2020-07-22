using UnityEngine;

public class Shot : MonoBehaviour
{
	[SerializeField] private Rigidbody _rigidbody;
	[SerializeField] private float _speed = 100.0f;
	[SerializeField] private int _damage = 1;
	[SerializeField] private Damager _damager;

	private void Start()
	{
		_rigidbody.velocity = transform.forward * _speed;
	}

	private void OnTriggerEnter(Collider collider)
	{
		_damager.Damage(collider.gameObject, _damage);
	}
}