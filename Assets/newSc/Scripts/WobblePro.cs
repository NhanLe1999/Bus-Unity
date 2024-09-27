using UnityEngine;

public class WobblePro : MonoBehaviour
{
	public new Transform transform;

	public Renderer rend;

	private Vector3 lastPos;

	private Vector3 velocity;

	private Vector3 lastRot;

	private Vector3 angularVelocity;

	public float MaxWobble;

	public float wobbleSpeed;

	public float Recovery;

	private float wobbleX;

	private float wobbleZ;

	private float wobbleAmountToAddX;

	private float wobbleAmountToAddZ;

	private float pulse;

	private float time;

	private const string WobbleX = "_Wx";

	private const string WobbleZ = "_Wz";

	private void OnEnable()
	{
	}

	private void Update()
	{
	}
}
