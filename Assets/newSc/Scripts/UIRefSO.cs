using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = " UIRef SO", menuName = "SO/IU Ref So")]
public class UIRefSO : ScriptableObject
{
	public static UIRefSO ins;

	public List<UICanvasPrime> uiCanvasRefList;

	private void Awake()
	{
	}
}
