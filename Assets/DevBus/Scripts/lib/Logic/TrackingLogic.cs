using Firebase.Analytics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingLogic
{
    private const string keyFTUE = "FTUE_";
    private const string US_PlayTime = "US_PlayTime_";
    private const string Accumulated_Count = "acc";
    ITrackingService firebaseService = new FireBaseService();

    GameManager gameManager;
    public TrackingLogic()
    {
       
    }

    public void Init()
    {
        InitService();
        gameManager = GameManager.instance;
    }

    public void LogEvent(string message)
    {
        firebaseService.LogEvent(message);
    }

    public void FTUELogEvent(string mesage)
    {
        FTUELogEventWithParam(mesage);
    }
    public void FTUELogEventWithParam(string mesage)
    {
        LogEventWithParam(mesage);
    }

    private void accumulatedCount(string key)
    {
        var coun = PlayerPrefs.GetInt(Accumulated_Count + key, 0);
        coun++;
        PlayerPrefs.SetInt(Accumulated_Count + key, coun);
        PlayerPrefs.Save();
    }
    private int getCountAccmulated(string key)
    {
        return PlayerPrefs.GetInt(Accumulated_Count + key, 0);
    }

    public void ResetLogUsPlayTime()
    {
        /*PlayerPrefs.SetInt(US_PlayTime + TrackingConst.Us_play_60s, 0);
        PlayerPrefs.SetInt(US_PlayTime + TrackingConst.Us_play_300s, 0);
        PlayerPrefs.SetInt(US_PlayTime + TrackingConst.fn_play_480s, 0);*/
    }


    public void LogEvent(string message, Dictionary<string, string> parameters)
    {
        firebaseService.LogEvent(message, parameters);
    }
    public void LogEventWithParam(string message)
    {
        var dict = new Dictionary<string, string>();

        LogEvent(message, dict);
    }
    public void LogEventWithParam(string message, Dictionary<string, string> dict)
    {
        var temp = new Dictionary<string, string>();
        temp = Clone(dict);
        LogEvent(message, temp);
    }
    public Dictionary<string, string> Clone(Dictionary<string, string> dict)
    {
        var dictTemp = new Dictionary<string, string>();
        foreach (KeyValuePair<string, string> item in dict)
        {
            dictTemp.Add(item.Key, item.Value);
        }
        return dictTemp;
    }
    public void LogEventAds_Tracking(string message, Dictionary<string, string> _dict)
    {
       // this.accumulatedCount(message);
        var dict = Clone(_dict);
        LogEvent(message, dict);
    }
    private bool isDictKeyContain(string key, Dictionary<string, string> dict)
    {
        return dict.ContainsKey(key);
    }
    public void LogEventAds_Tracking(string message)
    {
        this.accumulatedCount(message);
        var dictionary = new Dictionary<string, string>();
        LogEvent(message, dictionary);

    }
    public void InitService()
    {

        firebaseService.InitService();
     //   appsflyerService.InitService();
    }

    public void HandleResourceChange(string key, string source, int amount)
    {
        firebaseService.ResourceChange(key, source, amount);
    }

    public void HandleIAP(string productId, string price, string currency)
    {
        firebaseService.HandleIAP(productId, price, currency);
    }

}
