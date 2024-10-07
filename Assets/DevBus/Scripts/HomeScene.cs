using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class HomeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIDailyBonusCanvas.Show();

        if (PlayerPrefs.HasKey("CurrentDay_Login"))
        {
            ScStatic.DayFirstLogin = DateTime.Parse(PlayerPrefs.GetString("CurrentDay_Login"));
        }
        else
        {
            DateTime now = DateTime.Now;
            now = now.AddDays(-1);
            ScStatic.DayFirstLogin = new DateTime(now.Year, now.Month, now.Day, 2, 0, 0);
            PlayerPrefs.SetString("CurrentDay_Login", ScStatic.DayFirstLogin.ToString());
        }

        var timeNow = DateTime.Now;
        var timeDistance = timeNow - ScStatic.DayFirstLogin;

        var dayNew = timeDistance.Days;

        if (dayNew > HelperManager.DataPlayer.numDayLogin)
        {
            HelperManager.DataPlayer.numDayLogin = dayNew;
            HelperManager.DataPlayer.stateLogin = ScStatic.STATE_LOGIN_NEW;
        }
    }


    private void OnDestroy()
    {
        HelperManager.Save();
    }
}
