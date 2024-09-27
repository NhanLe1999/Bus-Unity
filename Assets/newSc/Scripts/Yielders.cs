using System.Collections.Generic;
using UnityEngine;

public static class Yielders
{
	private static Dictionary<float, WaitForSeconds> _timeInterval;

	private static WaitForEndOfFrame _endOfFrame;

	private static WaitForFixedUpdate _fixedUpdate;

	public static WaitForEndOfFrame EndOfFrame => null;

	public static WaitForFixedUpdate FixedUpdate => null;

	public static WaitForSeconds Get(float seconds)
	{
		return null;
	}
}
