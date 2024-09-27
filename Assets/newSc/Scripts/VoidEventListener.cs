using UnityEngine;
using UnityEngine.Events;

public class VoidEventListener : MonoBehaviour
{
	[SerializeField]
	private VoidEventChannelSO channel;

	public UnityEvent OnEventRaised;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Respond()
	{
	}
}
