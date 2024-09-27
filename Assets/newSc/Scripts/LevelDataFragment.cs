using System;
using UnityEngine;
using _Game.Scripts.Bus;

[Serializable]
[CreateAssetMenu(menuName = "Stuff/Data Fragment/Level Fragment", fileName = "Level Fragment")]
public class LevelDataFragment : DataFragment
{
	[Serializable]
	public class Data
	{
		public int level;

		public bool isSwapCarTutShowed;

		public bool isVipBusTutShowed;

		public bool isSwapMinionTutShowed;
	}

	public static LevelDataFragment cur;

	public BusLevelSO[] busLevelSoList;

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

	public void LoadLevel()
	{
	}

	public int GetLevelIndex()
	{
		return 0;
	}

	public int GetFireBaseLevel()
	{
		return 0;
	}

	public void AscendLevel()
	{
	}

	public bool CheckTutLevel(out int flag)
	{
		flag = default(int);
		return false;
	}

	public bool IsBabySitLevel()
	{
		return false;
	}
}
