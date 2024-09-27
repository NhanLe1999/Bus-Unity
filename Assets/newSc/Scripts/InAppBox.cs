using UnityEngine;

public class InAppBox : MonoBehaviour
{
	public new GameObject gameObject;

	[SerializeField]
	private float boxHeight;

	public float BoxHeight => 0f;

	public bool IsActive { get; private set; }

	public void Enable(bool isOn, bool isHideOnInit = true)
	{
	}
}
