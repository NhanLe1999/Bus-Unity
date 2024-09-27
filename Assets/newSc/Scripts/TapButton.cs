using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class TapButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
{
	public UnityEvent tapEvent;

	public void OnPointerDown(PointerEventData eventData)
	{
	}
}
