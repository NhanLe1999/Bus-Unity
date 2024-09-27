using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.Bus
{
	[Serializable]
	[CreateAssetMenu(menuName = "Bus Level", fileName = "Bus Level")]
	public class BusLevelSO : ScriptableObject
	{
		public static BusLevelSO active;

		public BusMapHardness busMapHardness;

		public List<BusPosData> busPosDatas;

		public List<TunnelDataPack> tunnelDataPacks;

		public int totalMinionNum;

		public AnchorPointData[] anchorPoints;

		public List<int> grayBusIndexes;

		public void LoadLevel()
		{
		}

		public void SaveLevel()
		{
		}

		private List<int> ConvertToIndexList(List<Bus> busList, List<Bus> nodeList)
		{
			return null;
		}

		private List<Bus> ConvertToBusList(List<Bus> busList, List<int> indexList)
		{
			return null;
		}

		public List<AnchorPoint> GetAnchorPoints()
		{
			return null;
		}
	}
}
