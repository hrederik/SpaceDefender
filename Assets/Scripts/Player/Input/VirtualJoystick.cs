using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IController
{
	[SerializeField] private RectTransform _area;
	[SerializeField] private RectTransform _thumb;
	private float _halfSizeArea;
	private Vector2 _areaOriginalPosition;
	private Vector2 _thumbOriginalPosition;	
	private Vector2 _delta;
	public Vector2 Delta => _delta;

	private void Start()
	{
		_halfSizeArea = _area.rect.width / 2;
		_areaOriginalPosition = _area.localPosition;
		_thumbOriginalPosition = _thumb.localPosition;		
	}
	
	public void OnBeginDrag(PointerEventData eventData)
	{
		_area.position = GetPointerWorldPosition(_area, eventData);
	}

	public void OnDrag(PointerEventData eventData)
	{
		_thumb.position = GetPointerWorldPosition(_area, eventData);

		_delta = _thumb.localPosition / _halfSizeArea;
		_delta.x = Mathf.Clamp(_delta.x, -1.0f, 1.0f);
		_delta.y = Mathf.Clamp(_delta.y, -1.0f, 1.0f);
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		ResetJoystickPosition();
		ResetDelta();
	}

	public void ResetDelta()
	{
		_delta = Vector2.zero;
	}

	private Vector3 GetPointerWorldPosition(RectTransform area, PointerEventData eventData)
	{
		Vector3 worldPosition;
		RectTransformUtility.ScreenPointToWorldPointInRectangle(area, eventData.position, eventData.enterEventCamera, out worldPosition);

		return worldPosition;
	}

	private void ResetJoystickPosition()
	{
		_area.localPosition = _areaOriginalPosition;
		_thumb.localPosition = _thumbOriginalPosition;
	}
}