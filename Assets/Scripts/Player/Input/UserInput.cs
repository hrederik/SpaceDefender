using UnityEngine;

public class UserInput : MonoBehaviour
{
	[SerializeField] private VirtualJoystick _joystick;
	[SerializeField] private Accelerometer _accelerometer;
	private IController _controller;
	public Vector2 Direction { get; private set; }

	private void Awake()
	{
		SetJoystick();
	}

	private void Update()
	{
		Direction = _controller.Delta;
	}

	public void SetJoystick()
	{
		_controller = _joystick;
	}

	public void ResetSteering()
	{
		_joystick.ResetDelta();
	}
}