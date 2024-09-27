using System;
using UnityEngine;

namespace _Game.Scripts.Bus
{
	[Serializable]
	public struct GizmoData
	{
		public int depth;

		public Vector3 start;

		public Vector3 end;

		public Bus bus;

		public Bus targetBus;
	}
}
