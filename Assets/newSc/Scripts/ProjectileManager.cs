using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
	public static ProjectileManager ins;

	public Stack<ProjectileVariation>[] grandPool;

	private void Awake()
	{
	}

	public ProjectileVariation Pop(ProjectileType projectileType, Vector3 pos, Quaternion rot)
	{
		return null;
	}

	public void Push(ProjectileVariation projectileVariation)
	{
	}
}
