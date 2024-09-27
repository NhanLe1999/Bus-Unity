using UnityEngine;
using UnityEngine.Events;

public class IntEventListener : MonoBehaviour
{
	[SerializeField]
	private IntEventChannelSO channel;

	public UnityEvent<int> OnEventRaised;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Respond(int value)
	{
	}
}
