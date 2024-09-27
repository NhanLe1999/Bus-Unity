using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.Bus
{
	public class BusStation : MonoBehaviour
	{
		private struct SwitchData
		{
			public bool isBusTaken;

			public bool isBusCarTaken;

			public bool isBusVanTaken;

			public JunkColor color;
		}

		public static BusStation cur;

		public List<Bus> activeBus;

		public List<Bus> groundBus;

		public List<BusTunnel> activeTunnels;

		public AnimationCurve spreadCurve;

		private const int MIN_MINION_PER_CALL = 21;

		public List<AnchorPoint> anchorPoints;

		public List<BusColorData> AwaitBusDatas { get; set; }

		public List<BusColorDataWithBackTrack> AwaitForFetchDataBus { get; set; }

		public List<BusColorData> PenaltyColorData { get; set; }

		public bool IsVipBus { get; set; }

		public Bus CurrentVipBus { get; set; }

		public int MovedBus { get; set; }

		public List<Bus> GrayBuses { get; set; }

		private void Awake()
		{
		}

		public bool CallOfDuty(out List<JunkColor> menAtWar)
		{
			menAtWar = null;
			return false;
		}

		private bool IsTunnelRanOutData()
		{
			return false;
		}

		private List<JunkColor> ExtractColorData(List<Bus> busList)
		{
			return null;
		}

		public void CheckAwaitData(List<Bus> list)
		{
		}

		public void CheckForNull(ref List<Bus> list)
		{
		}

		private int GetMinionNumFromBuses(List<Bus> list)
		{
			return 0;
		}

		public void CheckAnchorPoint(List<Bus> list)
		{
		}

		public List<Bus> SearchForNodeAtLeast(int weight, int minNum)
		{
			return null;
		}

		public List<Bus> SearchForNodeAtLeastLastChance(int weightMin, int weightMax, int minNum)
		{
			return null;
		}

		public void CheckFromTunnel(List<Bus> list)
		{
		}

		public void RemoveFromActiveBuses(Bus bus)
		{
		}

		public void RemoveFromGroundBuses(Bus bus)
		{
		}

		public List<JunkColor> RawMinions(List<BusColorData> colorList)
		{
			return null;
		}

		public List<JunkColor> MixMinions(List<BusColorData> colorList)
		{
			return null;
		}

		private List<JunkColor> SpreadColor(float spread, BusColorData firstData, BusColorData secondData)
		{
			return null;
		}

		public List<BusColorData> MergeBusColorData(List<BusColorData> list)
		{
			return null;
		}

		public void BoosterUltraRandomColor()
		{
		}

		public bool IsVipBusAble()
		{
			return false;
		}

		public void BoosterVipBus()
		{
		}

		public void BoosterMinionsMix()
		{
		}

		public bool ProcessPenaltyColor(List<JunkColor> colorList)
		{
			return false;
		}

		public void CheckGrayBus()
		{
		}
	}
}
