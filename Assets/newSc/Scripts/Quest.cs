using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Stuff/Quest/Quest", fileName = "Quest ")]
public class Quest : ScriptableObject
{
	[Serializable]
	public class QuestData
	{
		public bool isClaimed;

		public List<QuestProgressData> questProgressDatas;
	}

	[Serializable]
	public class QuestSubProgress
	{
		public QuestIdentify questIdentify;

		[HideInInspector]
		public int current;

		public int goal;

		public string targetDescription;

		public bool CheckComplete()
		{
			return false;
		}
	}

	[Serializable]
	public class QuestProgressData
	{
		public QuestIdentify questIdentify;

		public int current;

		public QuestProgressData(QuestIdentify questIdentify)
		{
		}
	}

	public QuestSubProgress[] questSubProgressList;

	[SerializeField]
	private string uniqueKey;

	[SerializeField]
	private QuestData questData;

	public bool MakeReward()
	{
		return false;
	}

	public bool CheckFinish()
	{
		return false;
	}

	public bool IsClaimed()
	{
		return false;
	}

	public void PushProgress(QuestIdentify questIdentify, int value)
	{
	}

	public void UpdateProgress(QuestIdentify questIdentify, int value)
	{
	}

	public void ResetData()
	{
	}

	public void Load()
	{
	}

	public void Save()
	{
	}

	private QuestData New()
	{
		return null;
	}

	public void LogCurrent()
	{
	}
}
