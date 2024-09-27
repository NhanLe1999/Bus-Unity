using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class HoldButtonSupreme : MonoBehaviour, IPointerUpHandler, IEventSystemHandler, IPointerDownHandler
{
	public bool IsInteractable;

	public UnityEvent onPointerDown;

	public UnityEvent onPointerUp;

	public UnityEvent onHold;

	private bool isHold;

	private void Update()
	{
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}

	public void OnPointerUp(PointerEventData eventData)
	{
	}
}
