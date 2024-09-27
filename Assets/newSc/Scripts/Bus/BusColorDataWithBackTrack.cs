using System;
using System.Collections.Generic;

namespace _Game.Scripts.Bus
{
	[Serializable]
	public struct BusColorDataWithBackTrack
	{
		public int num;

		public JunkColor color;

		public List<Bus> backTrackList;

		public override string ToString()
		{
			return null;
		}

		public BusColorData GetColorData()
		{
			return default(BusColorData);
		}

		public void DecreaseWeight()
		{
		}
	}
}
