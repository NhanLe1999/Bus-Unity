using System;
using UnityEngine;

public class GrandManager : SingleTons<GrandManager>
{
	private bool isNet;

	private bool isCount;

	private static bool isAOA;

	private static int timeFailed;


	[HideInInspector]
	public bool isReviewing;

	public float interTimePoint;

	public bool IsInternetConnected { get; set; }

	public float playTime { get; set; }

	public bool IsSettingOpen { get; set; }

	public bool IsPause { get; set; }

	public bool IsHome { get; private set; }

	public bool IsGame { get; private set; }

	public bool IsChallenge { get; private set; }

	public int WinConcurrentNum { get; set; }

	public int LoseConcurrentNum { get; set; }

	public bool FlagIsFirstLose { get; set; }

	private void Start()
	{
	}

	private void OnStart()
	{
	}

	private void Update()
	{
	}

	public bool RequireInter(bool isLose, string placement, Action onDone = null)
	{
		return false;
	}

	private void TruncateTimePoint()
	{
	}

	public void TriggerPenalty()
	{
	}

	public void ResetFirstLoseFlag()
	{
	}

	public void ResetCapping()
	{
	}

	private void CheckHandle()
	{
	}

	public void ResetFlag()
	{
	}

	private void OnLowMemory()
	{
	}

	private static void GameSetting()
	{
	}

	private void OnApplicationPause(bool pauseStatus)
	{
	}

	public void InitHome()
	{
	}

	public void InitLevel()
	{
	}

	public void IntoHome()
	{
	}

	public void IntoHome(Action onDoneTransit)
	{
	}

	public void InToGame()
	{
	}

	public void InToGame(Action onDoneTransit)
	{
	}

	public void IntoChallenge()
	{
	}

	public void IntoChallenge(Action onDoneTransit)
	{
	}

	private void IntoHomeHandle()
	{
	}

	private void IntoLevelHandle()
	{
	}

	private void IntoChallengeHandle()
	{
	}

	public void PauseGame()
	{
	}

	public void UnpauseGame()
	{
	}

	public void CallReview()
	{
	}
}
