using UnityEngine;

public class MapBaseLine : MonoBehaviour
{
	public Transform root;

	private Quaternion upLeftDir;

	private Quaternion upRightDir;

	[SerializeField]
	private float offsetAngle;

	[SerializeField]
	private Color gridColor;

	[SerializeField]
	private int res;

	[SerializeField]
	private float width;

	[SerializeField]
	private bool isDraw;

	private void Update()
	{
	}

	private void OnDrawGizmos()
	{
	}
}
