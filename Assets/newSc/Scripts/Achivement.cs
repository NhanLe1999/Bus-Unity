using System;
using UnityEngine;

[Serializable]
public class Achivement
{
	public AchiveIdentify achiveType;

	public string[] achiveName;

	public int[] achiveGoal;

	[HideInInspector]
	public int current;

	[HideInInspector]
	public int curIndex;

	[SerializeField]
	private int goldReward;

	public bool GetCurrentAchiveState()
	{
		return false;
	}
}
