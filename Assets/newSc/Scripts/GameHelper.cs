using System;
using System.Collections.Generic;
using UnityEngine;

public static class GameHelper
{
	private static System.Random rng;

	public static int CurrentTimeInSecond => 0;

	public static int GetDayNow => 0;

	public static Vector2 WorldToCanvas(this Canvas canvas, Vector3 world_position, Camera camera = null)
	{
		return default(Vector2);
	}

	public static float GetAngle(this Transform t, Vector3 target)
	{
		return 0f;
	}

	public static float GetAngle(this Vector3 t, Vector3 target)
	{
		return 0f;
	}

	public static float GetAngle(this Vector3 t)
	{
		return 0f;
	}

	public static float GetAngle(this Vector2 t)
	{
		return 0f;
	}

	public static float GetAngleZero(this Vector3 t, Vector3 target)
	{
		return 0f;
	}

	public static float Lerp(this float t, float b, float s)
	{
		return 0f;
	}

	public static T ToEnum<T>(this string value)
	{
		return default(T);
	}

	public static T ToEnum<T>(this int value)
	{
		return default(T);
	}

	public static float PlayerPref_float(string key, float v)
	{
		return 0f;
	}

	public static float PlayerPref_float(string key)
	{
		return 0f;
	}

	public static int PlayerPref_int(string key, int v)
	{
		return 0;
	}

	public static int PlayerPref_int(string key)
	{
		return 0;
	}

	public static string PlayerPref_string(string key)
	{
		return null;
	}

	public static List<GameObject> GetAllChilds(this Transform t)
	{
		return null;
	}

	public static void RemoveAllChild(this Transform t)
	{
	}

	public static void RemoveChildren(Transform t)
	{
	}

	public static void DisableAllChild(this Transform t)
	{
	}

	public static void RemoveAllChildOnEditor(this Transform t)
	{
	}

	public static void Shuffle<T>(this T[] array)
	{
	}

	public static void Shuffle<T>(this List<T> array)
	{
	}

	public static List<Vector3> FlipList(this List<Vector3> l)
	{
		return null;
	}

	public static T DeepClone<T>(T obj)
	{
		return default(T);
	}

	public static void SetSizeX(this SpriteRenderer render, int size)
	{
	}

	public static void SetSizeY(this SpriteRenderer render, int size)
	{
	}

	public static Color SetColorAlpha(Color c, float a)
	{
		return default(Color);
	}

	public static void FlipX(this Transform t)
	{
	}

	public static void FlipX(this Transform t, int dir)
	{
	}

	public static string FormatTimeMMSS(int second)
	{
		return null;
	}

	public static string FormatTimeHHMMSS(int second)
	{
		return null;
	}
}
