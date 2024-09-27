using UnityEngine;

namespace _Game.Scripts.Bus
{
	public class AnimMesher : MonoBehaviour
	{
		public static AnimMesher cur;

		public Mesh[] idleMeshes;

		public Mesh[] runMeshes;

		public Mesh[] sitMeshes;

		private int idleCount;

		private int runCount;

		private int sitCount;

		[SerializeField]
		private float idleTimeToIndex;

		[SerializeField]
		private float runTimeToIndex;

		[SerializeField]
		private float sitTimeToIndex;

		private void Awake()
		{
		}

		public Mesh GetIdle(float time)
		{
			return null;
		}

		public Mesh GetRun(float time)
		{
			return null;
		}

		public Mesh GetSit(float time)
		{
			return null;
		}
	}
}
