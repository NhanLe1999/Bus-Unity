using DG.Tweening;
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public enum TYPE_ITEM
{
    CHANG_CAR = 0,
    CHANGE_PLAYER = 1,
    VIP = 2,
    COIN = 3
}


[Serializable]
public class DataBuy
{
    public TYPE_ITEM typeItem;
    public int numItemReciver = 0;
    public TextMeshProUGUI txtItem = null;
    public Sprite spr;
}

class DataMinMaxAngle
{
    public float min;
    public float max;
    public DataMinMaxAngle(float min, float max)
    {
        this.min = min;
        this.max = max;
    }
}


public class UILuckyWheelCanvas : Dialog<UILuckyWheelCanvas>
{
    public Transform wheelTransform; 
    public float spinDuration = 4f; 
    public int itemCount = 15;        

    private float anglePerItem;      
    private bool isSpinning = false;

    [SerializeField] GameObject preItem = null;
    List<SpinItem> spinItems = new();

    List<DataMinMaxAngle> dataMinMax = new();
    [SerializeField] Button btnSpin = null;
    [SerializeField] TextMeshProUGUI txtNumSpin = null;

    [SerializeField] List<DataBuy> dataSpins = null;
    [SerializeField] List<Sprite> spritesItem = null;
    [SerializeField] RectTransform rectTrAnim = null;
    [SerializeField] TextMeshProUGUI txtAddItem = null;
    [SerializeField] Image imgSlideBar = null;
    [SerializeField] TextMeshProUGUI txtWinLuckyWheel = null;
    [SerializeField] TextMeshProUGUI txtDesWinLuckyWheel = null;



    Vector3 pointBegin = Vector3.zero;
    CanvasGroup canvasGroup = null;
    Image imgItemReciver = null;


    private int index = 0;
    void Start()
    {
        txtDesWinLuckyWheel.text = $"Win {ScStatic.numTotalWinToLuckyWheel} levels to spin the wheel";

        if (HelperManager.DataPlayer.numWinLevel >= ScStatic.numTotalWinToLuckyWheel)
        {
            HelperManager.DataPlayer.NumTotalSpin++;
            HelperManager.DataPlayer.numWinLevel = HelperManager.DataPlayer.numWinLevel - ScStatic.numTotalWinToLuckyWheel;
            HelperManager.DataPlayer.isWin5Level = true;
            txtDesWinLuckyWheel.text = $"Win {ScStatic.numTotalWinToLuckyWheel} levels to spin the wheel";
        }

        txtWinLuckyWheel.text = $"{HelperManager.DataPlayer.numWinLevel}/{ScStatic.numTotalWinToLuckyWheel}";
        imgSlideBar.fillAmount =(float) HelperManager.DataPlayer.numWinLevel / (float)ScStatic.numTotalWinToLuckyWheel;

        HomeScene.Instance.txtWinLuckyWheel.text = $"{HelperManager.DataPlayer.numWinLevel}/{ScStatic.numTotalWinToLuckyWheel}";

        HomeScene.Instance.objCoin.transform.parent = transform;
        anglePerItem = 360f / itemCount;
        CreateWheelItems();
        btnSpin.interactable = HelperManager.DataPlayer.NumTotalSpin > 0;
        pointBegin = rectTrAnim.anchoredPosition;
        txtNumSpin.text = HelperManager.DataPlayer.NumTotalSpin.ToString();
        canvasGroup = rectTrAnim.GetComponent<CanvasGroup>();
        imgItemReciver = rectTrAnim.GetComponent<Image>();
    }

    void runAnim()
    {
        canvasGroup.alpha = 1.0f;
        rectTrAnim.DOAnchorPos(pointBegin + new Vector3(0, 800, 0), 2.0f).SetEase(Ease.OutQuad);
        canvasGroup.DOFade(0, 0.5f).SetDelay(1.5f).OnComplete(() => {

            rectTrAnim.anchoredPosition = pointBegin;

        });
    }    

    public void StartSpin()
    {
        if (isSpinning) return;

        HelperManager.DataPlayer.NumTotalSpin--;
        btnSpin.interactable = HelperManager.DataPlayer.NumTotalSpin > 0;
        txtNumSpin.text = HelperManager.DataPlayer.NumTotalSpin.ToString();

        isSpinning = true;

        float randomAngle = UnityEngine.Random.Range(0f, 360f);
        float totalAngle = 360f * UnityEngine.Random.Range(7, 10) + randomAngle; // Spin 10 rounds and stop at a random angle

        wheelTransform.DORotate(new Vector3(0, 0, -totalAngle), spinDuration, RotateMode.FastBeyond360)
            .SetEase(Ease.OutCubic)
            .OnComplete(() => {
                isSpinning = false;
                ShowReward(randomAngle);
            });
    }

    void CreateWheelItems()
    {
        float numA = 360.0f / itemCount;
        numA = numA / 2;

        for (int i = 0; i < itemCount; i++)
        {
            float angle = i * anglePerItem;
            GameObject item = Instantiate(preItem, wheelTransform);
            item.transform.localRotation = Quaternion.Euler(0, 0, angle); // Rotate item
            item.name = ((int)angle).ToString();
            var cpn = item.GetComponent<SpinItem>();
            var sp = dataSpins[i].spr;
            cpn.SetDataBuy(dataSpins[i], sp);
            spinItems.Add(cpn);
           // angle = 360.0f - angle;
            dataMinMax.Add(new DataMinMaxAngle(angle - numA, angle + numA)); ;

        }
    }

    private void ShowReward(float finalAngle)
    {
        int index = 0;

        for(int i = 0;  i < dataMinMax.Count; i++)
        {
            var item = dataMinMax[i];
            if (item.min < finalAngle && item.max > finalAngle)
            {
                index = i;
                break;
            }
        }

        HelperManager.UpdateItemForSkill(dataSpins[index].typeItem, dataSpins[index].numItemReciver);
        imgItemReciver.sprite = dataSpins[index].spr;
        imgItemReciver.SetNativeSize();
        txtAddItem.text = "+" + dataSpins[index].numItemReciver.ToString();
        runAnim();
        Debug.Log(spinItems[index].name + "_____" + finalAngle + "__min: " + dataMinMax[index].min + "___max: " + dataMinMax[index].max);
    }

    public static void Show()
    {
        Open();
    }
    public static void Hide()
    {
        //MobileMonetizationPro_AdmobAdsInitializer.instance?.SetActiveBanner(true);
        Close();
    }

    public void onClose()
    {
        HomeScene.Instance.objCoin.transform.parent = HomeScene.Instance.transform;
        Hide();
    }

}
