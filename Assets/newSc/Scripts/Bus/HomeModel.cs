using UnityEngine;

namespace _Game.Scripts.Bus
{
	public class HomeModel : MonoBehaviour
	{
		public static HomeModel cur;

		public Transform homeCamRestPoint;

		public Transform homeCamRefPoint;

		public GameObject lightObject;

		private void Awake()
		{
		}
	}
}
