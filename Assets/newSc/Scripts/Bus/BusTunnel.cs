using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace _Game.Scripts.Bus
{
	public class BusTunnel : MonoBehaviour
	{
		public new Transform transform;

		public new GameObject gameObject;

		public Transform busParkTrans;

		public Transform busInitTrans;

		[SerializeField]
		private Bus targetLockBus;

		private Tween moveBusTween;

		private Tween scaleBusTween;

		public List<TunnelBusData> awaitBuses;

		private readonly List<Bus> linkedBusList;

		public TMP_Text numLeftText;

		public Transform barrierTrans;

		[SerializeField]
		private Vector3 rootBarrierRotate;

		[SerializeField]
		private Vector3 targetBarrierRotate;

		private Tween barrierTween;

		public BusHollow busHollow;

		private List<Bus> blockBusList;

		private bool isSignalAccepted;

		public bool IsPushed { get; set; }

		public bool IsOutOfData { get; set; }

		public Bus CurrentLockBus { get; private set; }

		public int AwaitDataCount => 0;

		public void OnInit()
		{
		}

		public void OnPush()
		{
		}

		public TunnelDataPack ExtractDataPack()
		{
			return default(TunnelDataPack);
		}

		public void FetchData(TunnelDataPack dataPack)
		{
		}

		private void DecreaseWeight()
		{
		}

		public void OnBusMoveOutParkZone()
		{
		}

		private Bus ConvertToBus(TunnelBusData data)
		{
			return null;
		}

		private void AppendBus(Bus bus)
		{
		}

		public BusColorData HandOutData(bool isTakeFirstOnly)
		{
			return default(BusColorData);
		}

		private int GetSeatNum(BusType busType)
		{
			return 0;
		}

		public int GetTotalMinionNum()
		{
			return 0;
		}
	}
}
