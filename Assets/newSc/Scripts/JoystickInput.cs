using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickInput : MonoBehaviour, IDragHandler, IEventSystemHandler, IPointerDownHandler, IPointerUpHandler
{
	public static JoystickInput ins;

	private bool isClickable;

	private Vector2 mouseDownPos;

	private Vector2 mouseUpPos;

	public RectTransform joystickBackground;

	public RectTransform joystickHandle;

	public RectTransform joystickPanel;

	public GameObject joystick;

	[SerializeField]
	private float joystickMaxDistance;

	[HideInInspector]
	public Vector3 moveDir;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void OnDrag(PointerEventData eventData)
	{
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}

	public void OnPointerUp(PointerEventData eventData)
	{
	}

	public void SetBackState()
	{
	}

	public void SetLockState(bool isLock)
	{
	}
}
