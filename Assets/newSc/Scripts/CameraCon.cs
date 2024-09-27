using DG.Tweening;
using UnityEngine;

public class CameraCon : SingleTons<CameraCon>
{
	public Camera cam;

	public new Transform transform;

	public new GameObject gameObject;

	private float cur;

	private Tween camMoveTween;

	private Tween camRotTween;

	[SerializeField]
	private float rootOrthoSize;

	private Tween curShakeTween;

	private Tween curReturnTween;

	private int curMaxStrength;

	private void Start()
	{
	}

	public void SwitchPerspective()
	{
	}

	public void SwitchOrthographic()
	{
	}

	public void MoveCam(Transform target, float duration = 1f, Ease moveEase = Ease.Linear, Ease rotEase = Ease.Linear)
	{
	}

	public void MoveCam(Vector3 target, Vector3 eulerAngles, float duration = 1f, Ease moveEase = Ease.Linear, Ease rotEase = Ease.Linear)
	{
	}

	public void MoveCamLocal(Transform target, float duration = 1f, Ease moveEase = Ease.Linear, Ease rotEase = Ease.Linear)
	{
	}

	public void MoveCamFollow(Transform target, Transform restPoint, float duration = 1f, Ease moveEase = Ease.Linear, Ease rotEase = Ease.Linear)
	{
	}

	public void ShakeCam(int strength = 1)
	{
	}

	public void ContinuesShakeCam(int strength = 1)
	{
	}

	public void SetRestPoint(Transform restPoint)
	{
	}

	public void CamOffsetToRatioAdaption()
	{
	}

	public void AdjustCamOrthoSizeToRatioAdaption()
	{
	}
}
