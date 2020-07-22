using UnityEngine;

public class ShipEngine : MonoBehaviour
{
	[SerializeField] private Transform _ship;
	[SerializeField] private AudioSource _sound;
	[SerializeField] private float _maxSpeed = 15;
	[SerializeField] private float _speed = 5.0f;
	public float Speed => _speed;
	public float MaxSpeed => _maxSpeed;

	// TODO: Попробовать движение через Rigidbody.velocity

	private void Update()
	{
		var offset = Vector3.forward * Time.deltaTime * _speed;
		_ship.Translate(offset);
	}

	public void OnSpeedChanged(float value)
	{
		SetSpeed(value);
		SetVolume(value);
	}

	private void SetSpeed(float value)
	{
		_speed = value * _maxSpeed; 
	}

	private void SetVolume(float volume)
	{
		_sound.volume = volume;
	}
}