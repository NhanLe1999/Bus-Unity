using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Stuff/Data Fragment/Heart Fragment", fileName = "Heart Fragment")]
public class HeartDataFragment : DataFragment
{
	[Serializable]
	public class Data
	{
		public DateTime baseOpenTime;

		public long baseOpenTimeLong;

		public int trackingDayIndex;

		public bool isClaimedToday;

		public bool isClaimMoreToday;
	}

	public static HeartDataFragment cur;

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

	public bool CheckNewDay(out TimeSpan timeLeft)
	{
		timeLeft = default(TimeSpan);
		return false;
	}

	public int GetCurrentDayIndex()
	{
		return 0;
	}
}
