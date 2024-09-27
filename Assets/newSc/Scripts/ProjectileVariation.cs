using UnityEngine;

public class ProjectileVariation : MonoBehaviour
{
	public new Transform transform;

	public new GameObject gameObject;

	public ProjectileType projectileType;

	[SerializeField]
	private bool isAutoPush;

	[SerializeField]
	private float lifeTime;

	public bool IsScaleChanged { get; set; }

	public Vector3 RootScale { get; private set; }

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	public ProjectileVariation SetScale(Vector3 scale)
	{
		return null;
	}
}
