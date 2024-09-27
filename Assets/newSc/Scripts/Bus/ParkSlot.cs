using UnityEngine;
using UnityEngine.EventSystems;

namespace _Game.Scripts.Bus
{
	[SelectionBase]
	public class ParkSlot : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
	{
		public new Transform transform;

		public GameObject adsObject;

		[SerializeField]
		private bool isVipSlot;

		public Bus AssignedBus { get; set; }

		public bool IsSlotTaken { get; set; }

		public bool IsBusArrive { get; set; }

		public bool IsAdsSlot { get; set; }

		public bool IsVipSlot => false;

		public void OnPointerDown(PointerEventData eventData)
		{
		}

		public void UnlockSlot()
		{
		}

		public void PreParkTheBus(Bus bus)
		{
		}

		public void ReleaseBus()
		{
		}

		public void SetupVipSlot(bool isOn)
		{
		}

		public void SetupSlot(bool isAdsSlot)
		{
		}

		public (Vector3, Vector3) GetEnterAndRestPoint(Plane upPlane)
		{
			return default((Vector3, Vector3));
		}
	}
}
