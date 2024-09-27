using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.Bus
{
	[Serializable]
	public struct TunnelDataPack
	{
		public List<TunnelBusData> datas;

		public Vector3 position;

		public Quaternion rotation;

		public int lockBusIndex;

		public List<int> blockBusIndexList;
	}
}
