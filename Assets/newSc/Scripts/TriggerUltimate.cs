using UnityEngine;
using UnityEngine.Events;

public class TriggerUltimate : MonoBehaviour
{
	[SerializeField]
	private bool isMultiTrigger;

	public UnityEvent onTrigger;

	private bool isTrigger;

	[TagSelector]
	[SerializeField]
	private string colTag;

	private void OnTriggerEnter(Collider other)
	{
	}
}
