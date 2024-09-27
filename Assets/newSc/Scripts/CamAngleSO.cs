using UnityEngine;

[CreateAssetMenu(fileName = "Cam Angle", menuName = "SO/Cam Angle")]
public class CamAngleSO : ScriptableObject
{
	public float[] camMul;

	public float GetMaxMul()
	{
		return 0f;
	}

	public float GetMinMul()
	{
		return 0f;
	}
}
