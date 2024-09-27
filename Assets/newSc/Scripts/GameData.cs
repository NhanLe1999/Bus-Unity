using System;

[Serializable]
public class GameData
{
	public int dataKey;

	public bool isFirstOpen;

	public int itemDictVer;

	public bool isMusicOn;

	public bool isSoundOn;

	public float musicVolume;

	public float soundVolume;

	public bool isVibrateOn;

	public DateTime baseOpenTime;

	public long baseOpenTimeLong;

	public int levelCheckpointStart;

	public int levelCheckPointEnd;

	public int dayPlayed;

	public int rewardWatched;

	public int interWatched;

	public float purchasedValue;

	public int firstTryLevelMark;

	public void INit()
	{
	}

	private void InitItemDict()
	{
	}
}
