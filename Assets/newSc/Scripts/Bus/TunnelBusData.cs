using System;

namespace _Game.Scripts.Bus
{
	[Serializable]
	public struct TunnelBusData
	{
		public BusType busType;

		public JunkColor color;

		public bool isTaken;
	}
}
