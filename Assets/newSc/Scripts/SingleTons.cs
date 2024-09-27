using UnityEngine;

public class SingleTons<T> : MonoBehaviour where T : MonoBehaviour
{
	public static T ins;

	[SerializeField]
	private bool isDontDesTroyOnLoad;

	protected bool isAwakable;

	[SerializeField]
	private bool isDestroyOldInstance;

	protected virtual void Awake()
	{
	}
}
