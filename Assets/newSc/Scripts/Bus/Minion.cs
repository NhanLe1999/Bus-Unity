using DG.Tweening;
using UnityEngine;

namespace _Game.Scripts.Bus
{
	[SelectionBase]
	public class Minion : MonoBehaviour
	{
		public new GameObject gameObject;

		public new Transform transform;

		[SerializeField]
		private Vector3 onBusScale;

		public Renderer rend;

		private Tween moveQueueTween;

		public AnimMeshPlayer anim;

		public static int ANIM_IDLE;

		public static int ANIM_RUN;

		public static int ANIM_SEAT;

		public static Quaternion onWaitLineQuaternion;

		private Vector3 onBoardLastPos;

		private Vector3 onBoardCurPos;

		private int currentAnim;

		public Vector3 RootScale { get; private set; }

		public Vector3 OnBusScale => default(Vector3);

		public JunkColor Color { get; set; }

		public bool IsPushed { get; set; }

		public bool IsInActiveList { get; set; }

		public bool IsOnBoard { get; set; }

		public int QueueIndex { get; private set; }

		private void Awake()
		{
		}

		public void OnInit()
		{
		}

		public void EnterQueue(int index)
		{
		}

		public void MoveNextInQueue()
		{
		}

		public void AddQueueIndex(int num)
		{
		}

		public void MoveQueueSegment(float per)
		{
		}

		public void InitOnboardRotation()
		{
		}

		public void OnboardRotate()
		{
		}

		public void SetAnim(int targetAnim, bool isForceAnim = false)
		{
		}

		public void PopOnColorChange()
		{
		}
	}
}
