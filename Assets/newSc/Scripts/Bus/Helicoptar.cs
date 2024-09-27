using System;
using DG.Tweening;
using UnityEngine;

namespace _Game.Scripts.Bus
{
	public class Helicoptar : MonoBehaviour
	{
		public static Helicoptar cur;

		public new Transform transform;

		public new GameObject gameObject;

		[SerializeField]
		private float outSideDistance;

		[SerializeField]
		private float flyHeight;

		[SerializeField]
		private float moveSpeed;

		private Tween moveTween;

		private Bus currentBus;

		private void Awake()
		{
		}

		public void Reposition()
		{
		}

		public void PickupBus(Bus bus, Action onDone = null)
		{
		}
	}
}
