using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Stuff/Data Fragment/Daily Fragment", fileName = "Daily Fragment")]
public class DailyRewardDataFragment : DataFragment
{
	[Serializable]
	public class Data
	{
		public DateTime baseOpenTime;

		public long baseOpenTimeLong;

		public double lastFreeTime;

		public List<bool> itemFlags;
	}

	public static DailyRewardDataFragment cur;

	public Data gameData;

	private void Awake()
	{
	}

	public override void Load()
	{
	}

	public override void Save()
	{
	}

	public override void ResetData()
	{
	}

	public bool CheckNewDailyDay(out TimeSpan timeLeft)
	{
		timeLeft = default(TimeSpan);
		return false;
	}

	public void OnNewDayRefresh()
	{
	}

	public void PrepareCountDown()
	{
	}

	public bool CheckIfItsTimeToFree(out TimeSpan timeLeft)
	{
		timeLeft = default(TimeSpan);
		return false;
	}
}
