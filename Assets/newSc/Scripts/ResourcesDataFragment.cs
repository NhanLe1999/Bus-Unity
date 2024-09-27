using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Stuff/Data Fragment/Resources Fragment", fileName = "Resources Fragment")]
public class ResourcesDataFragment : DataFragment
{
	[Serializable]
	public class Data
	{
		public int gold;

		public int swapCarNum;

		public int vipBusNum;

		public int swapMinionNum;

		public int pendingGold;

		public int pendingSwapCar;

		public int pendingVipBus;

		public int pendingSwapMinion;
	}

	public static ResourcesDataFragment cur;

	public Data gameData;

	[SerializeField]
	private int swapCarPrice;

	[SerializeField]
	private int vipBusPrice;

	[SerializeField]
	private int swapMinionPrice;

	[SerializeField]
	private string[] boosterNames;

	public int Gold => 0;

	public int SwapCarNum => 0;

	public int VipBusNum => 0;

	public int SwapMinionNum => 0;

	public int SwapCarPrice => 0;

	public int VipBusPrice => 0;

	public int SwapMinionPrice => 0;

	public string[] BoosterNames => null;

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

	public void AddGold(int amount, string placement, bool isTruncatePending = false)
	{
	}

	public void AddSwapCar(int amount, string placement, bool isTruncatePending = false)
	{
	}

	public void AddVipBus(int amount, string placement, bool isTruncatePending = false)
	{
	}

	public void AddSwapMinion(int amount, string placement, bool isTruncatePending = false)
	{
	}

	public void PendingGold(int amount, string placement)
	{
	}

	public void PendingSwapCar(int amount, string placement)
	{
	}

	public void PendingVipBus(int amount, string placement)
	{
	}

	public void PendingSwapMinion(int amount, string placement)
	{
	}

	public void ProcessPending()
	{
	}

	public void ProcessPendingGold()
	{
	}
}
