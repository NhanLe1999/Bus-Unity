using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class CheckAdsReward : MonoBehaviour
{

	private CanvasGroup canvasGroup;

	public Image imgIconAds;

	public Image btnImg;

	public Sprite imgOn;

	public float alphaDisable;

	[HideInInspector]
	public bool isLoadNeeded;

	private bool isAds;

	private bool isAdsOld;

	private void OnEnable()
	{
	}

	private IEnumerator ie_Check()
	{
		return null;
	}

	public void Ads()
	{
	}

	public void NotAds()
	{
	}

	public void Remove()
	{
	}
}
