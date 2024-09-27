using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Stuff/Data Fragment/Quest Fragment", fileName = "Quest Fragment")]
public class QuestDataFragment : DataFragment
{
	[Serializable]
	public class Data
	{
		public DateTime baseOpenTime;

		public long baseOpenTimeLong;

		public int weeklyEnergy;

		public bool[] rewardState;
	}

	public static QuestDataFragment cur;

	public VoidEventChannelSO onGainWeeklyExp;

	public Data gameData;

	public Quest[] questList;

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

	public bool CheckNewQuestDay(out TimeSpan timeLeft)
	{
		timeLeft = default(TimeSpan);
		return false;
	}

	public bool CheckNewQuestWeek(out TimeSpan timeLeft)
	{
		timeLeft = default(TimeSpan);
		return false;
	}

	public void AddWeeklyEnergy(int amount)
	{
	}

	public void ResetQuestData()
	{
	}
}
