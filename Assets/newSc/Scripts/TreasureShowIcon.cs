using TMPro;
using UnityEngine;

public class TreasureShowIcon : MonoBehaviour
{
	public new GameObject gameObject;

	public RectTransform rect;

	[SerializeField]
	private bool isGoldItem;

	public CanvasGroup canvasGroup;

	public TMP_Text itemNumText;

	//public ParticleImage splashEffect;

	public bool IsGoldItem => false;

	public void PopFromChest(Vector2 pos, Vector3 rot)
	{
	}

	public void SetNum(int num)
	{
	}

	public void PopNormal()
	{
	}

	public void PopDisappear()
	{
	}

	public void PopFromShowToPlay()
	{
	}

	public void SetPos(Vector2 pos)
	{
	}

	public Vector2 GetCanvasPos()
	{
		return default(Vector2);
	}

	public void SetEnable(bool isOn)
	{
	}
}
