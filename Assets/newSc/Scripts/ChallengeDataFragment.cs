using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Stuff/Data Fragment/Challenge Fragment", fileName = "Challenge Fragment")]
public class ChallengeDataFragment : DataFragment
{
	[Serializable]
	public class Data
	{
		public DateTime baseOpenTime;

		public long baseOpenTimeLong;

		public bool isUnlockAll;

		public int currentMonth;

		public bool[] rewardState;

		public bool[] tickedDay;

		public bool isChallengeTut;

		public bool isTutOpened;

		public bool isTutCamOpened;

		public bool isTutWoodOpened;

		public int markTutDay;
	}

	public static ChallengeDataFragment cur;

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

	public bool IsDayTicked(int day)
	{
		return false;
	}

	public void TickDay(int day)
	{
	}

	public int GetTotalTickedDays()
	{
		return 0;
	}

	public bool CheckNewDay()
	{
		return false;
	}

	public bool IsLoadTutChallenge(int day)
	{
		return false;
	}
}
