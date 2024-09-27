using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class HoldButtonComp : MonoBehaviour, IPointerUpHandler, IEventSystemHandler, IPointerDownHandler
{
	public bool IsInteractable;

	public UnityEvent unityEvent;

	[SerializeField]
	private float holdTime;

	private float timer;

	[SerializeField]
	private float mulRect;

	public Image filler;

	public RectTransform buttonRect;

	private Tween curZoomTween;

	private bool isHold;

	private bool isUpdate;

	private void Update()
	{
	}

	private void OnDestroy()
	{
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}

	public void OnPointerUp(PointerEventData eventData)
	{
	}
}
