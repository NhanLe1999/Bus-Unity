using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScStatic
{
    public static string PLAYERDATA = "Bus_Data";

    public static string GAME_SCENE = "GameScene";
    public static string HOME_SCENE = "HomeScene";

    public static string MUSIC_HOME = "Home";
    public static string MUSIC_GAME = "Game";

    public static string SFX_TAPSOUND = "SFX_TAPSOUND";
    public static string SFX_BUTTONSOUND = "SFX_BUTTONSOUND";
    public static string SFX_HIT_SOUND = "SFX_HIT_SOUND";
    public static string SFX_SHORT_SOUND = "SFX_SHORT_SOUND";
    public static string SFX_FULL_SOUND = "SFX_FULL_SOUND";
    public static string SFX_WIN_SOUND = "SFX_WIN_SOUND";
    public static string SFX_FAIL_SOUND = "SFX_FAIL_SOUND";
    public static string SFX_MOVING_SOUND = "SFX_MOVING_SOUND";
    public static string SFX_NOCOIN_SOUND = "SFX_NOCOIN_SOUND";
    public static string SFX_WARING = "SFX_WARING";


    public static string STATE_LOGIN_NEW = "new";
    public static string STATE_LOGIN_DEFAUL = "default";
    public static string STATE_LOGIN_CLAIM = "claim";


    public static bool IsUseAdsOpenApp = false;

    public static int numTotalWinToLuckyWheel
    {
        get { 
            if(HelperManager.DataPlayer.isWin5Level)
            {
                return 10;
            }
            return 5;
        }
    }

    public static string KEY_DAILY_BOUNUS_IS_CLAIM
    {
        get { return $"coin_daily_isclaim{HelperManager.DataPlayer.numDayLogin}"; }
    }

    public static DateTime DayFirstLogin { get; set; }

}
