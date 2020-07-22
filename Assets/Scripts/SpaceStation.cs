using UnityEngine;

public class SpaceStation : Damageable
{
	[SerializeField] private GameState _gameState;
	[SerializeField] private IndicatorBuilder _indicatorManager;
	[SerializeField] private Color _indicatorColor;
	[SerializeField] private AudioSource _audioSource;
	[SerializeField] private AudioClip[] _hitSounds;
	[SerializeField] private Damager _damager;
	[SerializeField] private int _damage;

	private void Start()
	{
		_indicatorManager.Create()
			.SetOwner(transform)
			.SetColor(_indicatorColor);
	}

	private void OnCollisionEnter(Collision collision)
	{
		_damager.Damage(collision.gameObject, _damage);
	}

	protected override void OnDamage()
	{
		PlaySound();
		Handheld.Vibrate();
	}

	protected override void OnDeath()
	{
		_gameState.EndGame();
		Destroy(gameObject);
	}

	private void PlaySound()
	{
		_audioSource.clip = GetRandomSound(_hitSounds);
		_audioSource.Play();
	}

	private AudioClip GetRandomSound(AudioClip[] sounds)
	{
		return sounds[Random.Range(0, sounds.Length)];
	}
}