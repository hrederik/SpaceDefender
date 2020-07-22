using UnityEngine;

public class RemoveAfterDelay : MonoBehaviour
{
	[SerializeField] private float _delay = 1.0f;

	private void Start()
	{
		Destroy(gameObject, _delay);
	}
}
