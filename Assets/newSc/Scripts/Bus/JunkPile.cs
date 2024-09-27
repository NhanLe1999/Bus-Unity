using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.Bus
{
	public class JunkPile : MonoBehaviour
	{
		public static JunkPile ins;

		private readonly Stack<Bus> carPool;

		public Bus carPrefab;

		private readonly Stack<Bus> vanPool;

		public Bus vanPrefab;

		private readonly Stack<Bus> busPool;

		public Bus busPrefab;

		public Material[] busMats;

		private readonly Stack<Minion> minionPool;

		public Minion minionPrefab;

		public MatrixPrime<Material> minionMats;

		private readonly Stack<BusTunnel> busTunnelPool;

		public BusTunnel busTunnelPrefab;

		private readonly List<Bus> activeBuses;

		private readonly List<Minion> activeMinions;

		private readonly List<BusTunnel> activeTunnels;

		public Material[] busGrayMats;

		public Material[] busRainbowMats;

		public List<Minion> ActiveMinions => null;

		private void Awake()
		{
		}

		public Bus GetBus(BusType type, JunkColor junkColor, Vector3 pos, Quaternion rotation)
		{
			return null;
		}

		public Minion GetMinion(JunkColor junkColor)
		{
			return null;
		}

		public BusTunnel GetTunnel()
		{
			return null;
		}

		public void Push(Bus bus)
		{
		}

		public void Push(Minion minion)
		{
		}

		public void Push(BusTunnel busTunnel)
		{
		}

		public void RecallAll()
		{
		}

		public void ChangeColor(Bus bus, JunkColor color)
		{
		}

		public void ChangeColor(Minion minion, JunkColor color)
		{
		}

		public void ChangeToGray(Bus bus, JunkColor color)
		{
		}

		public void ChangeToRainBow(Bus bus, JunkColor color)
		{
		}
	}
}
