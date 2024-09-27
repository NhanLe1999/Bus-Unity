using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Stuff/Events/Void Event Channel")]
public class VoidEventChannelSO : ScriptableObject
{
	public static Dictionary<VoidEventType, VoidEventChannelSO> dictionary;

	public UnityAction onEventRaised;

	[SerializeField]
	private VoidEventType eventType;

	private void Awake()
	{
	}

	private void AddToDict()
	{
	}

	public void RaiseEvent()
	{
	}

	public static void TriggerEvent(VoidEventType eventType)
	{
	}
}
