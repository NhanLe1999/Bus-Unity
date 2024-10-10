using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class HomeScene : SingletonMono<HomeScene>
{
    [SerializeField] GameObject objWarningDailyReWard = null;
    [SerializeField] RectTransform rectBtnPlay = null;
    [SerializeField] GameObject objSetting = null;
    [SerializeField] TextMeshProUGUI txtLevel = null;
    [SerializeField] Canvas canvas = null;
    [SerializeField] GameObject objTop = null;
    [SerializeField] List<RectTransform> rectPanal = null;
    public TextMeshProUGUI txtWinLuckyWheel = null;

    public GameObject objCoin = null;

    void Start()
    {
        Audio.PlayBackgroundMusic(ScStatic.MUSIC_HOME, 0.5f);

        txtWinLuckyWheel.text = $"{HelperManager.DataPlayer.numWinLevel}/{ScStatic.numTotalWinToLuckyWheel}";

        txtLevel.text = "Level " + HelperManager.DataPlayer.NumLevel.ToString();

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
        this.StartCoroutine(OnRunAnimButtonPlay());
        ResizeTop();
    }

    void ResizeTop()
    {
        var sizeCanvas = HelperManager.GetSizeOfCanvas(canvas);
        var rect = objTop.GetComponent<RectTransform>();
        var sizeTop = rect.sizeDelta;

       // if(sizeCanvas.x < sizeTop.x)
        {
            var scale = sizeCanvas.x / sizeTop.x;

            foreach(var it in rectPanal)
            {
                it.localScale = Vector3.one * scale;
            }
        }

    }

    private void OnDestroy()
    {
        HelperManager.Save();
    }

    public void OnCheckShowWarningDailyReward()
    {
        objWarningDailyReWard.SetActive(OnCheckDailyBonus());
    }

    private bool OnCheckDailyBonus()
    {
        DateTime resetTime;
        DateTime DateTiemNow = DateTime.Now;
        if (PlayerPrefs.HasKey("ResetTime"))
        {
            resetTime = DateTime.Parse(PlayerPrefs.GetString("ResetTime"));
        }
        else
        {
            DateTime now = DateTime.Now;
            resetTime = new DateTime(now.Year, now.Month, now.Day, 2, 0, 0);
            resetTime = resetTime.AddDays(-1);
        }
        return DateTiemNow >= resetTime;
    }

    public void OnShowLuckyWheel()
    {
        UILuckyWheelCanvas.Show();
    }   
    
    public void OnShowDailyReward()
    {
        UIDailyBonusCanvas.Show();
    }

    public void OnPlayGame()
    {
        HelperManager.OnLoadScene(ScStatic.GAME_SCENE);
    }

    IEnumerator OnRunAnimButtonPlay()
    {
        yield return new WaitForSeconds(0.5f);
        var recTransform = rectBtnPlay;

        Sequence buttonSequence = DOTween.Sequence();

        buttonSequence.Append(recTransform.DOScale(1.2f, 0.5f).SetEase(Ease.InOutSine))
                      .Append(recTransform.DOScale(1f, 0.5f).SetEase(Ease.InOutSine))
                      .Append(recTransform.DOScale(1.1f, 0.5f).SetEase(Ease.InOutSine))
                      .Append(recTransform.DOScale(1f, 0.5f).SetEase(Ease.InOutSine))
                      .SetUpdate(true)
                      .SetLoops(-1, LoopType.Restart);

        buttonSequence.Play();
    }

    public void OnShowSetting()
    {
        objSetting.SetActive(true);
    }

}
