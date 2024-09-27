using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingleTons<UIManager>
{
	public UIRefSO uiRefSO;

	private readonly Dictionary<Type, UICanvasPrime> uiCanvasReferenceDict;

	private readonly Dictionary<Type, UICanvasPrime> uiCanvasList;

	public Transform uiCanvasParentTrans;

	public AnimationCurve popCanvasCurve;

	[SerializeField]
	private float upperOffsetForOffer;

	[SerializeField]
	private float bottomOfferForOffer;

	public Dictionary<Type, UICanvasPrime> UICanvasList => null;

	public float UpperOffsetForOffer => 0f;

	public float BottomOffsetForOffer => 0f;

	protected override void Awake()
	{
	}

	private void InitCanvasData()
	{
	}

	private T LookForCanvas<T>() where T : UICanvasPrime
	{
		return null;
	}

	private T GetCanvasPrefab<T>() where T : UICanvasPrime
	{
		return null;
	}

	public T GetUICanvas<T>() where T : UICanvasPrime
	{
		return null;
	}

	public T OpenUI<T>() where T : UICanvasPrime
	{
		return null;
	}

	public void CloseUI<T>() where T : UICanvasPrime
	{
	}

	public bool IsUICanvasOpened<T>() where T : UICanvasPrime
	{
		return false;
	}

	public void CloseAllUI()
	{
	}

	public void CloseAllUI<T>() where T : UICanvasPrime
	{
	}
}
