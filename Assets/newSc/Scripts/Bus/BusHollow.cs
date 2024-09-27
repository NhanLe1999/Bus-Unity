using UnityEngine;

namespace _Game.Scripts.Bus
{
	public class BusHollow : Bus
	{
		public BusTunnel busTunnel;

		public BoxCollider[] busCollider;

		public void SetCollider(BusType busType)
		{
		}

		public void SneakInBus(Bus bus)
		{
		}

		public void SetDetectableByBus(bool isOn)
		{
		}

		public override void GetHit(Transform hitterTrans, Vector3 surfacePoint)
		{
		}
	}
}
