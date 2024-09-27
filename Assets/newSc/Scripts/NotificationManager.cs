using UnityEngine;

public class NotificationManager : SingleTons<NotificationManager>
{
	public const string NOTI12H = "Customers are waiting for you\nReturn to Bus Jam today";

	public const string NOTI20H = "It's time to relax. \nTake on the challenge and become the ultimate parking puzzle master";

	[SerializeField]
	public bool isPauseToShowAds;

	public void Start()
	{
	}

	public void Init()
	{
	}

	public void SendShortNoti(int time)
	{
	}

	public void OnApplicationPause(bool pause)
	{
	}

	public void OnApplicationQuit()
	{
	}

	public void SendQuitApplicationNotification()
	{
	}

	public void SendDayNotification()
	{
	}
}
