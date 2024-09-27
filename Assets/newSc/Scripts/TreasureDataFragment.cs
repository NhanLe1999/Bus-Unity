using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Stuff/Data Fragment/Treasure Fragment", fileName = "Treasure Fragment")]
public class TreasureDataFragment : DataFragment
{
	[Serializable]
	public class Data
	{
		public DateTime baseOpenTime;

		public long baseOpenTimeLong;

		public TreasureType lastTreasureType;

		public TreasureType currentTreasureType;

		public int currentProgress;

		public int currentLevel;

		public bool isTreasureOpened;
	}

	[Serializable]
	public class TreasureSetting
	{
		public RewardBundle[] minionRewardBundles;

		public RewardBundle[] busRewardBundles;

		public RewardBundle[] chest_1;

		public RewardBundle[] chest_2;

		public RewardBundle[] chest_3;

		public RewardBundle[] gift_1;

		public RewardBundle[] gift_2;

		public RewardBundle[] gift_3;

		public int[] minionReqPerLevel;

		public int[] busReqPerLevel;
	}

	[Serializable]
	public struct RewardBundle
	{
		public int rewardFlag;

		public int num;

		public RewardType GetRewardType()
		{
			return default(RewardType);
		}
	}

	public enum TreasureType
	{
		Minion = 0,
		Bus = 1
	}

	public enum RewardType
	{
		Gold = 0,
		SwapCar = 1,
		VipBus = 2,
		SwapMinion = 3,
		Chest_1 = 4,
		Chest_2 = 5,
		Chest_3 = 6,
		Gift_1 = 7,
		Gift_2 = 8,
		Gift_3 = 9
	}

	public static TreasureDataFragment cur;

	public Data gameData;

	public TreasureSetting treasureSetting;

	private static TimeSpan splitWeekOffset;

	private static TimeSpan postHalfWeek;

	private static TimeSpan fullWeek;

	public TreasureType CurrentTreasureType => default(TreasureType);

	public int RecordedNum { get; private set; }

	private void Awake()
	{
	}

	private void Reset()
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

	public bool IsTreasureAvailable()
	{
		return false;
	}

	public void HoldUnclaimedGift()
	{
	}

	public void ResetProgress()
	{
	}

	public bool CheckNewEventTime(out TimeSpan timeLeft)
	{
		timeLeft = default(TimeSpan);
		return false;
	}

	private void CheckTreasureType()
	{
	}

	public (int, int) GetCurrentAndRequireProgress()
	{
		return default((int, int));
	}

	public (int, int) GetCurrentAndRequireTruncateProgress()
	{
		return default((int, int));
	}

	public bool IsFullAtCurrentLevel()
	{
		return false;
	}

	public int GetCurrentCost()
	{
		return 0;
	}

	public int GetNextCost()
	{
		return 0;
	}

	public bool IncreaseLevel()
	{
		return false;
	}

	public bool IsOutLevel()
	{
		return false;
	}

	public int ProcessRecord()
	{
		return 0;
	}

	public void NukeRecord()
	{
	}

	public bool IsProgressOverLoad()
	{
		return false;
	}

	public void RecordObject(int amount, TreasureType treasureType)
	{
	}

	public RewardBundle GetCurrentGift()
	{
		return default(RewardBundle);
	}

	public RewardBundle[] GetChestGiftReward(RewardType rewardType)
	{
		return null;
	}

	public void PendingReward(RewardBundle rewardBundle, string goldPlacement = "")
	{
	}
}
