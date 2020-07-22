using UnityEngine;
using UnityEngine.UI;

public class Indicator : MonoBehaviour
{
	[SerializeField] private RectTransform _indicator;
	[SerializeField] private Image _image;
	[SerializeField] private Color _color;
	[SerializeField] private Text _distanceLabel;
	[SerializeField] private int _margin = 50;
	private Transform _owner;
	private Transform _target;
	private RectTransform _parent;

	private void Start()
	{
		_image.color = _color;

		if (_target != null) // Можно поместить в метод SetTarget
		{
			_distanceLabel.enabled = true;
			_distanceLabel.color = _color;
		}
		else
		{
			_distanceLabel.enabled = false;
		}
	}

	private void Update()
	{
		// Если цель присутствует, вычислить расстояние до нее и показать в distanceLabel
		if (_target != null) // TODO: Возможно сделать отдельные классы-наследники
		{
			float distance = Vector3.Magnitude(_target.position - _owner.position);
			_distanceLabel.text = $"{distance:N0}m";
		}

		Vector3 screenPoint = Camera.main.WorldToScreenPoint(_owner.position);
		if (screenPoint.z < 0)
		{
			screenPoint = screenPoint.normalized;
		}
		screenPoint = ApplyMargin(screenPoint, _margin);

		_indicator.localPosition = GetLocalPosition(_parent, screenPoint, Camera.main);
	}

	public void SetParent(RectTransform parent)
	{
		_parent = parent;
	}

	public void SetOwner(Transform owner)
	{
		_owner = owner;
	}

	public void SetTarget(Transform target)
	{
		_target = target;
	}

	public void SetColor(Color color)
	{
		_color = color;
	}

	public void SetSprite(Sprite sprite)
	{
		_image.sprite = sprite;
	}

	public void Destroy()
	{
		Destroy(gameObject);
	}

	private Vector2 ApplyMargin(Vector2 vector, int margin)
	{
		Vector2 result = new Vector2();

		result.x = Mathf.Clamp(vector.x, margin, Screen.width - margin * 2);
		result.y = Mathf.Clamp(vector.y, margin, Screen.height - margin * 2);

		return result;
	}

	private Vector2 GetLocalPosition(RectTransform rect, Vector3 point, Camera camera)
	{
		Vector2 localPosition;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, point, camera, out localPosition);

		return localPosition;
	}
}
