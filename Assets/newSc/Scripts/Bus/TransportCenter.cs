using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.Bus
{
	public class TransportCenter : MonoBehaviour
	{
		public static TransportCenter cur;

		private readonly WaitUntil waitUntilMinionStopMoving;

		private Coroutine minionTransportCor;

		private static readonly WaitUntil condition;

		public bool IsMinionTransporting { get; private set; }

		public bool IsBusLeaving { get; private set; }

		public bool IsGamePlaying { get; set; }

		public List<Bus> BusOnDutyQueue { get; set; }

		public Queue<Bus> BusLeaveQueue { get; set; }

		private void Awake()
		{
		}

		public bool IsTimeForBooster()
		{
			return false;
		}

		public void MinionEnter()
		{
		}

		public void StartMinionTransport(Bus bus = null)
		{
		}

		public void PauseMinionTransport()
		{
		}

		public void StopMinionTransport()
		{
		}

		public bool GetFittingBus(Minion minion, out Bus bus)
		{
			bus = null;
			return false;
		}

		public void RequireLeavePermit(Bus bus)
		{
		}

		public void StopBusLeavingProcess()
		{
		}

		public void InitializeMap()
		{
		}

		public void NukeMap()
		{
		}

		public void Callout()
		{
		}

		public void CheckEndGameStatus()
		{
		}

		public void WinHandle()
		{
		}

		private void LoseHandle()
		{
		}

		public void ReviveTransport()
		{
		}
	}
}
