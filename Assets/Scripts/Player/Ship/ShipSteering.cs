using UnityEngine;

public class ShipSteering : MonoBehaviour
{
	[SerializeField] private UserInput _userInput;
	[SerializeField] private float _turnRate = 6.0f;
	[SerializeField] private float _levelDamping = 1.0f;
	private Vector2 _rotation;
	private Transform _ship;

	private void Start()
	{
		_ship = transform;
	}

	private void Update()
	{
		// Создать новый поворот, умножив вектор направления джойстика
		// на turnRate, и ограничить виличиной 90% от половины круга
		_rotation.x = _userInput.Direction.y;
		_rotation.y = _userInput.Direction.x;

		// Получить величину поворота
		//_rotation *= _turnRate;

		// Преобразовать в радианы
		//_rotation.x = Mathf.Clamp(_rotation.x, -Mathf.PI * 0.9f, Mathf.PI * 0.9f);

		_rotation.x *= Mathf.Deg2Rad * _turnRate;
		_rotation.y *= Mathf.Deg2Rad * _turnRate;

		// Преобразовать радианы в кватернион поворота
		// Объединить поворот с текущей ориентацией
		_ship.rotation *= Quaternion.Euler(_rotation);

		// Далее попытаться минимизировать поворот
		// Сначала определить, какой была бы ориентация
		// в отсутствие вращения относительно оси Z
		var levelAngles = _ship.eulerAngles;
		levelAngles.z = 0.0f;
		var levelOrientation = Quaternion.Euler(levelAngles);

		// Объединить текущую ориентацию с небольшой величиной
		// этой ориентации "без вращения"; когда это происходит
		// на протяжении нескольких кадров, объект медленно
		// выравнивается над поверхностью
		_ship.rotation = Quaternion.Slerp(_ship.rotation, levelOrientation, _levelDamping * Time.deltaTime);
	}
}
