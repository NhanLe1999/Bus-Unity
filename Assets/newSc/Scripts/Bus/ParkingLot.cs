using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace _Game.Scripts.Bus
{
	public class ParkingLot : MonoBehaviour
	{
		private enum ExitDirection
		{
			Up = 0,
			Down = 1,
			Left = 2,
			Right = 3
		}

		public static ParkingLot cur;

		public Transform playCamRestPoint;

		public Transform onRoadPoint;

		[SerializeField]
		private Vector3 minPoint;

		[SerializeField]
		private Vector3 maxPoint;

		[SerializeField]
		private Vector3 minionRunAwayLinePoint;

		[SerializeField]
		private Vector3 endOfMinionLinePoint;

		private Plane upPlane;

		private Plane downPlane;

		private Plane leftPlane;

		private Plane rightPlane;

		public ParkSlot[] parkSlots;

		public Vector3[] minionsStandPos;

		private int minionStandPosMaxIndex;

		private Tween minionQueueMoveTween;

		private const float MINION_GROUND_OFFSET = 0.046f;

		public TMP_Text minionCountText;

		private int maxMinions;

		public GameObject lightObject;

		public Plane MinionPlane { get; private set; }

		public Vector3 MinionExitPoint { get; private set; }

		public Vector3 BusExitPoint { get; private set; }

		public bool IsMinionQueueMoving { get; private set; }

		public Queue<Minion> MinionsQueue { get; }

		public Queue<JunkColor> AwaitMinions { get; set; }

		public int MinionsLeft { get; private set; }

		private void Awake()
		{
		}

		[ContextMenu("FORCE START")]
		private void Start()
		{
		}

		public void UnlockPossibleAdsParkSlot()
		{
		}

		public bool IsAnyAdsSlotLeft()
		{
			return false;
		}

		public bool IsOneSlotLeft()
		{
			return false;
		}

		public void FetchMinionsNUm(int num)
		{
		}

		public float GetCompletePercent()
		{
			return 0f;
		}

		private (Vector3, ExitDirection) GetExitPoint(Vector3 point, Vector3 direction)
		{
			return default((Vector3, ExitDirection));
		}

		public void ResetAll()
		{
		}

		public bool IsAllSlotTaken(out ParkSlot parkSlot)
		{
			parkSlot = null;
			return false;
		}

		public ParkSlot GetVipSlot()
		{
			return null;
		}

		public (Vector3[], float) GeneratePath(ParkSlot parkSlot, Bus bus)
		{
			return default((Vector3[], float));
		}

		public (Vector3[], float) GenerateExitPath(ParkSlot parkSlot)
		{
			return default((Vector3[], float));
		}

		public (Vector3, Vector3) GetStandPointPair(int index)
		{
			return default((Vector3, Vector3));
		}

		public Vector3[] GetMinionPath(Bus bus)
		{
			return null;
		}

		public int GetStandPosNum()
		{
			return 0;
		}

		public void AddMinionToQueue(List<JunkColor> colors)
		{
		}

		public void EnqueueAwaitingMinions()
		{
		}

		public void AddMinionToQueue(Minion minion)
		{
		}

		public void JustMoveMinion(float speedMul = 1f)
		{
		}

		public void ReleaseMinionPostHandle()
		{
		}

		public void UpdateQueueIndex()
		{
		}

		public void MoveQueue(float per)
		{
		}

		public Minion GetCurrentMinion()
		{
			return null;
		}

		public Minion PopMinion()
		{
			return null;
		}
	}
}
