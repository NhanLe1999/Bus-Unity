using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum TYPE_CLAIM
{
    CLAIM = 0,
    CLAIMED = 1,
    CLAIMING = 2
}

[Serializable]
public class DataDailyBonus
{
    public int numDay = 1;
    public List<DataBuy> dataBuy;
}

public class UIDailyBonusCanvas : Dialog<UIDailyBonusCanvas>
{
    public DataDailyBonus[] dayData; 
    public Button claimButton; 
    public TextMeshProUGUI claimButtonText;
    [SerializeField] Transform trParentItem = null;
    private DateTime lastClaimTime;
    private int currentDay;
    DateTime resetTime;
    DateTime DateTiemNow;
    [SerializeField] Sprite imgBgItemDayly = null;

    private List<ItemDailyBonus> itemDailyBonus = new();

    [SerializeField] Transform trObBtnClaim = null;

    [SerializeField] Material materialTextGreen = null;
    [SerializeField] Color colorTextDone = Color.white;

    [SerializeField] RectTransform rectTrAnim = null;
    [SerializeField] TextMeshProUGUI txtAddItem = null;

    Vector3 pointBegin = Vector3.zero;
    CanvasGroup canvasGroup = null;
    Image imgItemReciver = null;



    void Start()
    {
        canvasGroup = rectTrAnim.GetComponent<CanvasGroup>();
        imgItemReciver = rectTrAnim.GetComponent<Image>();

        LoadPlayerData();
        UpdateUI();
    }

    void LoadPlayerData()
    {
        if (PlayerPrefs.HasKey("LastClaimTime"))
        {
            lastClaimTime = DateTime.Parse(PlayerPrefs.GetString("LastClaimTime"));
        }
        else
        {
            lastClaimTime = DateTime.Now;
        }

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

        if (PlayerPrefs.HasKey("CurrentDay"))
        {
            currentDay = PlayerPrefs.GetInt("CurrentDay");
        }
        else
        {
            currentDay = 0;
        }

        if(currentDay > 7)
        {
            currentDay = 0;
        }

        DateTiemNow = DateTime.Now;
    }

    void SavePlayerData()
    {
        PlayerPrefs.SetString("LastClaimTime", lastClaimTime.ToString());
        PlayerPrefs.SetInt("CurrentDay", currentDay);
        PlayerPrefs.SetString("ResetTime", resetTime.ToString());
    }

    void UpdateUI()
    {
        UpdateStateButtonClame();

        foreach (var item in dayData)
        {
            var obj = trParentItem.Find(item.numDay.ToString());
            var cpn = obj.GetComponent<ItemDailyBonus>();
            cpn.SetData(item);
            cpn.SetImgBg(imgBgItemDayly);
            cpn.UpdateUi();
            itemDailyBonus.Add(cpn);
        }

        for(int i = 0; i < currentDay; i++)
        {
            itemDailyBonus[i].SetTypeClaim(TYPE_CLAIM.CLAIMED);
        }    

        for(int i = currentDay + 1; i < currentDay; i++)
        {
            itemDailyBonus[i].SetTypeClaim(TYPE_CLAIM.CLAIMING, materialTextGreen);
        }

        if (!claimButton.interactable)
        {
            itemDailyBonus[currentDay - 1].SetTypeClaim(TYPE_CLAIM.CLAIM, materialTextGreen, colorTextDone);
        }
        else
        {
            itemDailyBonus[currentDay].SetTypeClaim(TYPE_CLAIM.CLAIM, materialTextGreen, colorTextDone);
        }
    }

    private void UpdateStateButtonClame()
    {
        claimButton.interactable = !PlayerPrefs.GetString(ScStatic.KEY_DAILY_BOUNUS_IS_CLAIM, "").Equals("true");
    }    

    bool IsTodayClaimed()
    {
        return DateTiemNow >= resetTime;
    }

    public void ClaimReward()
    {
        if (IsTodayClaimed())
        {
         //   MainMenu.Instance?.SetPointForTicketAnim(trObBtnClaim.position);
       //     MainMenu.Instance?.SetPointForScrewAnim(trObBtnClaim.position);

            var reward = itemDailyBonus[currentDay];
            claimButton.interactable = false;

            RecieverRequard(reward);

            /*  if (GameManager.instance.PlayerData.IsRemoveAds)
              {
                  ClaimAds();
              }    */

            // MainMenu.Instance.OnCheckShowWarningDailyReward();


            lastClaimTime = DateTime.Now;
            currentDay = (currentDay + 1) % itemDailyBonus.Count;

            DateTime now = DateTime.Now;
            resetTime = new DateTime(now.Year, now.Month, now.Day, 2, 0, 0);

            resetTime = resetTime.AddDays(1);

            PlayerPrefs.SetString(ScStatic.KEY_DAILY_BOUNUS_IS_CLAIM, "true");
            UpdateStateButtonClame();
            SavePlayerData();
            UpdateUI();
        }
    }

    private void RecieverRequard(ItemDailyBonus itemReWard)
    {
        foreach (var item in itemReWard.DataDaily.dataBuy)
        {
            HelperManager.UpdateItemForSkill(item.typeItem, item.numItemReciver);

            imgItemReciver.sprite = item.spr;
            imgItemReciver.SetNativeSize();
            txtAddItem.text = "+" + item.numItemReciver.ToString();

        }

        runAnim();

        //MainMenu.Instance?.OnUpdateTicketAndScrew();
    }

    public static void Show()
    {
        Open();
    }
    public static void Hide()
    {
        Close();
    }

    public void onClose()
    {
        Hide();
    }

    void runAnim()
    {
        canvasGroup.alpha = 1.0f;
        rectTrAnim.DOAnchorPos(pointBegin + new Vector3(0, 800, 0), 2.0f).SetEase(Ease.OutQuad);
        canvasGroup.DOFade(0, 0.5f).SetDelay(1.5f).OnComplete(() => {

            rectTrAnim.anchoredPosition = pointBegin;

        });
    }

}
