using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Stuff/Events/Bool Event Channel")]
public class BoolEventChannelSO : ScriptableObject
{
	public UnityAction<bool> onEventRaised;

	public void RaiseEvent(bool value)
	{
	}
}
