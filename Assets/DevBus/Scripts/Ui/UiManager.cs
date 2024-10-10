using DG.Tweening;
using System;
using System.Collections.Generic;
using TJ.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public struct DataLevelSkillGame
{
    public Sprite sprLevel;
    public Button btnSkill;
    public int levelIdLock;
    public TextMeshProUGUI txtLevelLock;
    public GameObject txtNumItem;

}

public class UiManager : MonoBehaviour
{

    public static UiManager instance;
    public GameObject gameOverPanle, winPanel, uiPause;

    [SerializeField] private Button btnSetting;
    [SerializeField] private Button btnNext;
    [SerializeField] private Button skipButton;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private List<GameObject> objBtnHomes;

    [SerializeField] RectTransform rectTrAnim = null;
    [SerializeField] TextMeshProUGUI txtAddItem = null;
    Vector3 pointBegin = Vector3.zero;
    CanvasGroup canvasGroup = null;
    Image imgItemReciver = null;
    int numCoinAdd = 10;
    bool isRunAnim = false;
    public TextMeshProUGUI txtNoti;
    public RectTransform rectNoti = null;

    public List<DataLevelSkillGame> dataLevelSkillGames;


    private void Awake()
    {
        instance = this;
    }

    private void SetDataForBtnSkill()
    {
        foreach(var it in dataLevelSkillGames)
        {
            if(it.levelIdLock > HelperManager.DataPlayer.NumLevel)
            {
                var imge = it.btnSkill.GetComponent<Image>();
                imge.sprite = it.sprLevel;
                imge.SetNativeSize();
                it.txtLevelLock.text = "Level " + it.levelIdLock.ToString();
                it.txtLevelLock.gameObject.SetActive(true);
                it.btnSkill.enabled = false;
                it.txtNumItem.SetActive(false);
            }
        }
    }

    private void Start()
    {
        foreach(var it in objBtnHomes)
        {
            it.SetActive(HelperManager.DataPlayer.NumLevel > 5);
        }
        SetDataForBtnSkill();
        numCoinAdd = 10;
        pointBegin = rectTrAnim.anchoredPosition;
        canvasGroup = rectTrAnim.GetComponent<CanvasGroup>();
        imgItemReciver = rectTrAnim.GetComponent<Image>();

        //next button for WinPanel
        btnNext.onClick.AddListener(() =>
        {
            Vibration.Vibrate(30);
            Audio.Play(ScStatic.SFX_BUTTONSOUND);
            HelperManager.OnLoadScene(ScStatic.GAME_SCENE);
        });
        skipButton.onClick.AddListener(() =>
        {
            LevelManager.LevelProgressed();
            Audio.Play(ScStatic.SFX_BUTTONSOUND);
            DOVirtual.DelayedCall(0.3f, LevelManager.LoadScene);
        });

        levelText.text = "Level " + HelperManager.DataPlayer.NumLevel.ToString();
    }

    public void OnShowSetting()
    {
        TogglePanel(uiPause, true);
    }

    public void TogglePanel(GameObject panel, bool value)
    {
        panel.SetActive(value);
    }

    public void OnHomeClick()
    {
        HelperManager.OnLoadScene(ScStatic.HOME_SCENE);
    }

    public void OnRestartClick()
    {
        HelperManager.OnLoadScene(ScStatic.GAME_SCENE);
    }

    public void OnClickClaimWin()
    {
        numCoinAdd = 20;
        txtAddItem.text = "+20";
        isRunAnim = true;
        runAnim(null);
        HelperManager.UpdateItemForSkill(TYPE_ITEM.COIN, 20);
        CoinsManager.Instance.UpdateCoinTxt();
    }

    public void OnClickBtnNextWin()
    {
        if(isRunAnim)
        {
            HelperManager.OnLoadScene(ScStatic.GAME_SCENE);
            return;
        }

        txtAddItem.text = "+10";
        HelperManager.UpdateItemForSkill(TYPE_ITEM.COIN, 10);
        CoinsManager.Instance.UpdateCoinTxt();
        runAnim(() => {
            HelperManager.OnLoadScene(ScStatic.GAME_SCENE);
        });
    }

    void runAnim(Action callback)
    {
        canvasGroup.alpha = 1.0f;
        rectTrAnim.DOAnchorPos(pointBegin + new Vector3(0, 800, 0), 2.0f).SetEase(Ease.OutQuad);
        canvasGroup.DOFade(0, 0.5f).SetDelay(1.5f).OnComplete(() => {
            callback?.Invoke();
            rectTrAnim.anchoredPosition = pointBegin;

        });
    }

    public void ShowPoupNoti(string txt)
    {
        if(rectNoti.gameObject.activeSelf && txtNoti.text.Equals(txt))
        {
            return;
        }

        txtNoti.text = txt;
        rectNoti.gameObject.SetActive(true);
        DOVirtual.DelayedCall(1f, () => {
            rectNoti.gameObject.SetActive(false);
        });
    }
}