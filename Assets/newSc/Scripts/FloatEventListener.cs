using UnityEngine;

public class FloatEventListener : MonoBehaviour
{
	[SerializeField]
	private FloatEventChannelSO channel;

	public FloatEvent OnEventRaised;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Respond(float value)
	{
	}
}
