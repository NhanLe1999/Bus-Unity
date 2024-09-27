using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CDPR_CCPA : MonoBehaviour
{
	public static CDPR_CCPA Ins;

	public GameObject GDPR;

	public GameObject CCPA;

	public Toggle toggleAgeGDPR;

	public Toggle toggleAgeCCPA;

	private Toggle toggleAge;

	public RectTransform transContentGDPR;

	public RectTransform transContentCCPA;

	[HideInInspector]
	public bool isComplete;

	[HideInInspector]
	public bool isAgree;

	[HideInInspector]
	public bool isCalifornia;

	private bool _isDetectCountryDone;

	private void Awake()
	{
	}

	public void Setup()
	{
	}

	private IEnumerator ie_Setup()
	{
		return null;
	}

	private IEnumerator DetectCountry()
	{
		return null;
	}

	public void Btn_Agree()
	{
	}

	public void BtnNoThanks()
	{
	}

	public void Btn_Ruler2()
	{
	}
}
