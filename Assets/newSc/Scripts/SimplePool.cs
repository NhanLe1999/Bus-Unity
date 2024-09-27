using System.Collections.Generic;
using UnityEngine;

public static class SimplePool
{
	private class Pool
	{
		private int nextId;

		private Stack<GameObject> inactive;

		private GameObject prefab;

		public Pool(GameObject prefab, int initialQty)
		{
		}

		public GameObject Spawn(Vector3 pos, Quaternion rot)
		{
			return null;
		}

		public void Despawn(GameObject obj)
		{
		}
	}

	private class PoolMember : MonoBehaviour
	{
		public Pool myPool;
	}

	private const int DEFAULT_POOL_SIZE = 3;

	private static Dictionary<GameObject, Pool> pools;

	private static void Init(GameObject prefab = null, int qty = 3)
	{
	}

	public static void Preload(GameObject prefab, int qty = 1)
	{
	}

	public static void Preload(GameObject prefab, Transform parent, int qty = 1)
	{
	}

	public static GameObject Spawn(GameObject prefab, Vector3 pos, Quaternion rot)
	{
		return null;
	}

	public static void Despawn(GameObject obj)
	{
	}
}
