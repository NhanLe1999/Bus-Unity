using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Stuff/Data Fragment/Buying Pack Fragment", fileName = "Buying Pack Fragment")]
public class BuyingPackDataFragment : DataFragment
{
	[Serializable]
	public class Data
	{
		public DateTime baseOpenTime;

		public long baseOpenTimeLong;

		public DateTime neverGiveUpTime;

		public long neverGiveUpTimeLong;

		public int consecutiveLoseNum;

		public bool isShowRemoveAds;

		public bool isShowStarterPack;

		public bool isShowRemoveAdsBundle;

		public bool isShowNeverGiveUp;

		public bool isStarterPackBought;

		public bool isNeverGiveUpEnable;

		public bool isBoughtNeverGiveUpLastTime;
	}

	public static BuyingPackDataFragment cur;

	public Data gameData;

	private const int TIME_SPACE_EIGHT_MINUTES = 480;

	private const int TIME_SPACE_TWELVE_MINUTES = 720;

	private const int TIME_SPACE_FIFTEEN_MINUTES = 900;

	private const int TIME_SPACE_TEN_MINUTES = 600;

	private const int TIME_SPACE_TWO_HOURS = 7200;

	private const int TIME_SPACE_FIVE_HOURS = 18000;

	private const int TIME_SPACE_EIGHT_HOURS = 28800;

	private float staterPackCappingTimePoint;

	private float adsBundleTimePoint;

	public bool IsSomethingShowing { get; set; }

	public bool IsShowingRemoveAds { get; set; }

	public bool IsShowingStarter { get; set; }

	public bool IsShowingRemoveAdsBundle { get; set; }

	public bool IsShowingNeverGiveUp { get; set; }

	public bool IsJustInter { get; set; }

	public int InterShowedNum { get; set; }

	public int ConsecutiveLoseNum
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	private void Awake()
	{
	}

	private void ResetStuff()
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

	public override void Update()
	{
	}

	public static void SetInterFlag()
	{
	}

	public void UpdateShowFlag()
	{
	}

	public void CheckShowOnHome()
	{
	}

	private bool IsShowRemoveAds()
	{
		return false;
	}

	private bool IsShowStarterPack()
	{
		return false;
	}

	private bool IsShowRemoveAdsBundle()
	{
		return false;
	}

	private bool IsShowNeverGiveUp()
	{
		return false;
	}

	public bool IsRemoveAdsCapping()
	{
		return false;
	}

	public bool IsCappingStarter()
	{
		return false;
	}

	public bool IsCappingRemoveAdsBundle()
	{
		return false;
	}

	public bool IsCappingNeverGiveUp()
	{
		return false;
	}

	public void CheatCapping()
	{
	}

	public bool CheckNeverGiveUpAvailable(out TimeSpan timeLeft)
	{
		timeLeft = default(TimeSpan);
		return false;
	}

	public void OnBuyNGUPackTimeHandle()
	{
	}
}
