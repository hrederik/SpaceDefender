using UnityEngine;

public class ShipTarget : MonoBehaviour
{
	[SerializeField] private IndicatorBuilder _indicatorBuilder;
	[SerializeField] private Sprite _aim;
	[SerializeField] private Color _color;

	private void Start()
	{
		_indicatorBuilder.Create()
			.SetOwner(transform)			
			.SetColor(_color)
			.SetSprite(_aim)
			.Build();
	}
}
