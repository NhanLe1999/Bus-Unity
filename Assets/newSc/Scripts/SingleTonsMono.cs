using UnityEngine;

public class SingleTonsMono<T> : MonoBehaviour where T : MonoBehaviour
{
	public static T ins;

	[SerializeField]
	private bool isDontDesTroyOnLoad;

	protected virtual void Awake()
	{
	}
}
