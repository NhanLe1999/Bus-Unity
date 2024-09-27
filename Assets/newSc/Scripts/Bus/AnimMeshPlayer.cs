using UnityEngine;

namespace _Game.Scripts.Bus
{
	public class AnimMeshPlayer : MonoBehaviour
	{
		public MeshFilter meshFilter;

		public static int ANIM_IDLE;

		public static int ANIM_RUN;

		public static int ANIM_SEAT;

		private int curAnim;

		private float time;

		public void PlayAnim(int anim)
		{
		}

		private void Update()
		{
		}
	}
}
