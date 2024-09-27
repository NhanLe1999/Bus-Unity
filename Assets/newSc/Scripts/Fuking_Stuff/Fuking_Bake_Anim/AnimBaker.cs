using UnityEngine;

namespace _Game.Scripts.Fuking_Stuff.Fuking_Bake_Anim
{
	public class AnimBaker : MonoBehaviour
	{
		public Animator animator;

		public SkinnedMeshRenderer skinnedMeshRenderer;

		public Transform skinnedMeshTrans;

		[SerializeField]
		private string animName;

		[SerializeField]
		private float step;

		[SerializeField]
		private string path;

		[SerializeField]
		private string preName;

		private void Start()
		{
		}
	}
}
