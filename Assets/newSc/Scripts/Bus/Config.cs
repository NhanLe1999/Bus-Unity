using UnityEngine;

namespace _Game.Scripts.Bus
{
	[CreateAssetMenu(menuName = "SO/Config", fileName = "Config")]
	public class Config : ScriptableObject
	{
		public static Config cur;

		[Header("Bus Map")]
		public float closeDistanceBetweenBuses;

		public float bounceBackDistance;

		public float busMoveSpeed;

		public float minionMoveSpeed;

		public float minionQueueSegmentMoveTime;

		public float busHeight;

		public float vanHeight;

		public float carHeight;

		public float delayBetweenBusLeave;

		public float averageBusParkPathLength;

		public float averageBusLeavePathLength;

		public float delayBetweenSwapCarBooster;

		public float delayBetweenSwapMinionBooster;

		[Header("In Game")]
		public int goldPerWin;

		public int goldPerRevive;

		[Header("Tut")]
		public int swapCarTutLevel;

		public int vipBusTutLevel;

		public int swapMinionTutLevel;

		[Header("Treasure Item")]
		public Vector3 treasureHomeDisplaySize;

		public Vector3 treasureHomeShowSize;

		private void Awake()
		{
		}
	}
}
