using UnityEngine;
using UnityEngine.UI;

public class ProgressBarPro : MonoBehaviour
{
	public Image image;

	[HideInInspector]
	public Material mat;

	private static int FILL;

	[SerializeField]
	[Range(0f, 1f)]
	private float fillAmount;

	public float FillAmount
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	private void Awake()
	{
	}
}
