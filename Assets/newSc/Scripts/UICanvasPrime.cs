using UnityEngine;

public class UICanvasPrime : MonoBehaviour
{
	public new GameObject gameObject;

	[SerializeField]
	protected bool isDestroyOnClose;

	public Canvas canvas;

	public static bool flagIsOpenTreasureShow;

	public virtual bool IsOpening()
	{
		return false;
	}

	public virtual void Open()
	{
	}

	protected virtual void OnOpenCanvas()
	{
	}

	public virtual void Close()
	{
	}

	protected virtual void OnCloseCanvas()
	{
	}

	private void Reset()
	{
	}
}
