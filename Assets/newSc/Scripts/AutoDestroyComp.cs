using UnityEngine;

public class AutoDestroyComp : MonoBehaviour
{
	public new GameObject gameObject;

	[SerializeField]
	private float delayTime;

	private void Awake()
	{
	}
}
