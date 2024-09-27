using UnityEngine;

public class BoolEventListener : MonoBehaviour
{
	[SerializeField]
	private BoolEventChannelSO channel;

	public BoolEvent OnEventRaised;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Respond(bool value)
	{
	}
}
