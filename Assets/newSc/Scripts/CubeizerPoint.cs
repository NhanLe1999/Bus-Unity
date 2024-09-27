using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CubeizerPoint : MonoBehaviour
{
	public Transform controlPointStart;

	public Transform controlPointEnd;

	public Transform endPoint;

	public Transform StartPoint;

	private void OnDrawGizmos()
	{
	}

	public void GetPathPoint(List<Vector3> path)
	{
	}

	public Vector3[] GetPath()
	{
		return null;
	}
}
