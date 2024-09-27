using UnityEngine;

public abstract class DataFragment : ScriptableObject
{
	[SerializeField]
	protected string key;

	public abstract void Load();

	public abstract void Save();

	public abstract void ResetData();

	public virtual void Update()
	{
	}

	protected void SaveData<T>(T obj, string uniqueKey)
	{
	}

	protected bool LoadData<T>(ref T data, string uniqueKey) where T : class
	{
		return false;
	}

	protected T LoadDataTest<T>(T data, string uniqueKey) where T : class
	{
		return null;
	}
}
