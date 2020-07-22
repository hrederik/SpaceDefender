using UnityEngine;

public class TargetFollowing : MonoBehaviour
{
	[SerializeField] private Transform _follower;
	[SerializeField] private Transform _target;
	[SerializeField] private float _height = 5.0f; // Высота камеры над целевым объектом
	[SerializeField] private float _distance = 10.0f; // Расстояние до целевого объекта без учета высоты
	[SerializeField] private float _rotationDamping;
	[SerializeField] private float _heightDamping;

	private void LateUpdate()
	{
		// Желаемые местоположение и ориентация
		float wantedRotationAngle = _target.eulerAngles.y;
		float wantedHeight = _target.position.y + _height;

		// Текущие местоположение и ориентация
		float currentRotationAngle = _follower.eulerAngles.y;
		float currentHeight = _follower.position.y;

		// Замедленный поворт
		currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, _rotationDamping * Time.deltaTime);

		// Корректировка высоты
		currentHeight = Mathf.Lerp(currentHeight, wantedHeight, _heightDamping * Time.deltaTime);

		// Преобразовывает угол в поворот
		Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

		// Устанавливает местоположение камеры в плоскости x-z
		// на расстоянии в "distance" метрах от цели
		_follower.position = _target.position;
		_follower.position -= currentRotation * Vector3.forward * _distance;

		// Установить местоположение камеры, используя новую высоту
		_follower.position = new Vector3(_follower.position.x, currentHeight, _follower.position.z);

		// Сориентировать объектив камеры в сторону направления целевого объекта
		_follower.rotation = Quaternion.Lerp(_follower.rotation, _target.rotation, _rotationDamping * Time.deltaTime);
	}
}
