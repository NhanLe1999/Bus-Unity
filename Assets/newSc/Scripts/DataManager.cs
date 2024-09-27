using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DataManager : SingleTons<DataManager>
{

	[SerializeField]
	private string fileName;

	private DataConvert dataConvert;

	public GameData gameData;

	private const int dataKey = 10320232;

	private const int itemDictVer = 26072024;

	public DataFragment[] dataFragmentList;

	private const string TIME_PLAY = "TimePlayPro";

	private const string FAIL_TIME = "Fail time";

	public bool IsDoneLoadData { get; private set; }

	private IEnumerator Start()
	{
		return null;
	}

	public GameData GetGameData()
	{
		return null;
	}

	private void NewGame()
	{
	}

	private void LoadData()
	{
	}

	private void UpdateItemDict()
	{
	}

	public void SaveData(bool isFragmentSave = true)
	{
	}

	private void OnApplicationPause(bool isPause)
	{
	}

	private void OnApplicationQuit()
	{
	}

	private void PostLoadingFragment()
	{
	}

	public bool CheckNewDay(out TimeSpan timeLeft)
	{
		timeLeft = default(TimeSpan);
		return false;
	}

	private void LoadTime()
	{
	}

	private void SaveTime()
	{
	}

	public void LogStart()
	{
	}

	public void LogComplete()
	{
	}

	public void LogFail()
	{
	}

	public bool IsFirstPlayLevel()
	{
		return false;
	}
}
