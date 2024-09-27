using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Stuff/Data Fragment/Spin Fragment", fileName = "Spin Fragment")]
public class SpinDataFragment : DataFragment
{
	[Serializable]
	public class Data
	{
		public int levelPassedNum;

		public int spinRank;
	}

	public static SpinDataFragment cur;

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

	public int GetRequiredPassedLevel()
	{
		return 0;
	}

	public void ConsumePassedLevel()
	{
	}

	public void PassedLevel()
	{
	}
}
