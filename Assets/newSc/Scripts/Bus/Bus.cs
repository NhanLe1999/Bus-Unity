using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Game.Scripts.Bus
{
	[SelectionBase]
	public class Bus : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
	{
		public new GameObject gameObject;

		public new Transform transform;

		public GameObject[] hideSeatModelObject;

		public GameObject[] showSeatModelObject;

		public Transform[] headPointTrans;

		public Transform upperModelTrans;

		public BoxCollider boxCollider;

		[SerializeField]
		private BusType busType;

		public JunkColor color;

		public Renderer[] mainColorRend;

		public List<Bus> nextNodeList;

		public List<Bus> backTrackNodeList;

		public List<Bus> directBackNodeList;

		[SerializeField]
		private float offsetFromHeadToCenter;

		private Tween shakeTween;

		private Tween moveTween;

		private Tween popTween;

		public GameObject smokeEffectObject;

		[SerializeField]
		private int maxMinions;

		private List<Minion> currentMinions;

		public Transform[] seatTransList;

		public Transform[] sideStepTransList;

		private Tween grayTween;

		public Vector3 RootScale { get; private set; }

		public BusType Type => default(BusType);

		public bool IsPushed { get; set; }

		public bool IsInActiveList { get; set; }

		public bool IsTouchable { get; set; }

		public bool IsOutOfTunnel { get; set; }

		public bool IsGrayBus { get; set; }

		public ParkSlot CurrentParkSlot { get; set; }

		public Quaternion RootUpperRotation { get; set; }

		public Vector3 RootPosition { get; set; }

		public bool IsStayOnBusZone { get; set; }

		public bool IsBusTaken { get; set; }

		public bool IsBusCarPartTaken { get; set; }

		public bool IsBusVanPartTaken { get; set; }

		public int Weight { get; set; }

		public int CurrentMinionNum { get; private set; }

		public int MaxMinion => 0;

		public Material CurrentGrayMat { get; set; }

		private void Awake()
		{
		}

		public void OnInit()
		{
		}

		public void OnPush()
		{
		}

		public void OnPointerDown(PointerEventData eventData)
		{
		}

		public void SetBusOpenOrHide(bool isHideSeat)
		{
		}

		public virtual void GetHit(Transform hitterTrans, Vector3 surfacePoint)
		{
		}

		public void Jiggle()
		{
		}

		public void OnMoveOutOfParkZone()
		{
		}

		public void Move()
		{
		}

		private Bus GetNextNode()
		{
			return null;
		}

		public bool IsClearAllNextNode()
		{
			return false;
		}

		public int GetBranchDepth()
		{
			return 0;
		}

		public int GetBranchWeight(List<Bus> countedBusList)
		{
			return 0;
		}

		public void DecreaseWeight()
		{
		}

		public void BackTrackAllNode()
		{
		}

		private void BackTrackAllNode(List<Bus> backList)
		{
		}

		private (Vector3, Vector3) GetHitPointAndPos(Bus targetBus)
		{
			return default((Vector3, Vector3));
		}

		public bool IsEmptySeat()
		{
			return false;
		}

		private void CheckReadyForGoing()
		{
		}

		public void LeaveTheCity()
		{
		}

		public void MinionOnBoard(Minion minion, Action onSitDown = null)
		{
		}

		private void PopOnMinionAbroad()
		{
		}

		public BusColorData GetColorData()
		{
			return default(BusColorData);
		}

		public BusColorDataWithBackTrack GetColorDataWithBackTrack()
		{
			return default(BusColorDataWithBackTrack);
		}

		public BusColorData GetRequireColorData()
		{
			return default(BusColorData);
		}

		public int GetTrueMinionNum()
		{
			return 0;
		}

		public void TurnToGray()
		{
		}

		public void TurnBackNormalFromGray()
		{
		}
	}
}
