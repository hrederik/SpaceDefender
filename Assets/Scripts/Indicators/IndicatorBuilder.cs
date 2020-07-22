using UnityEngine;

public class IndicatorBuilder : MonoBehaviour
{
	[SerializeField] private RectTransform _container;
	[SerializeField] public Indicator _indicatorPrefab;
	private Indicator _indicator;

	public IndicatorBuilder Create()
	{
		_indicator = Instantiate(_indicatorPrefab);
		_indicator.transform.SetParent(_container, false);
		_indicator.SetParent(_container);
		return this;
	}

	public IndicatorBuilder SetOwner(Transform owner)
	{
		_indicator.SetOwner(owner);
		return this;
	}

	public IndicatorBuilder SetTarget(Transform target)
	{
		_indicator.SetTarget(target);
		return this;
	}

	public IndicatorBuilder SetColor(Color color)
	{
		_indicator.SetColor(color);
		return this;
	}

	public IndicatorBuilder SetSprite(Sprite sprite)
	{
		_indicator.SetSprite(sprite);
		return this;
	}

	public Indicator Build()
	{
		return _indicator;
	}
}