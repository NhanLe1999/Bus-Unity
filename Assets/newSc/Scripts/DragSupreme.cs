using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class DragSupreme : MonoBehaviour, IDragHandler, IEventSystemHandler, IPointerDownHandler, IPointerUpHandler
{
	public RectTransform parentRect;

	public new GameObject gameObject;

	public bool IsDragable;

	public RectTransform rect;

	public bool isBackPos;

	public UnityEvent dragEvent;

	public UnityEvent onClickEvent;

	private Vector2 offset;

	private Vector2 rootPos;

	private Vector2 dragPos;

	private const float backMinDist = 420f;

	private const float backMaxDist = 720f;

	private Tween curBackPosTween;

	private void Start()
	{
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}

	public void OnPointerUp(PointerEventData eventData)
	{
	}

	private void BackPos()
	{
	}

	public void OnDrag(PointerEventData eventData)
	{
	}
}
