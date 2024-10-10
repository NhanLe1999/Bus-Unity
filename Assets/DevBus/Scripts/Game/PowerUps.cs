using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TJ.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
struct DataTextOfSkill
{
    public TYPE_ITEM type;
    public TextMeshProUGUI txtSkill;
}

public class PowerUps : MonoBehaviour
{
    public static PowerUps instance = null;
    public PowerUp currentPowerUp = PowerUp.None;
    public int shuffleCarCost;
    public int sortPlayerCost;
    public int VipPlayerCost;
    public int MoreSlot;
    public int GameOverSlot;

    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI info;
    [SerializeField] TextMeshProUGUI txtCoin;
    [SerializeField] Image icon;
    [SerializeField] Sprite carShuffleSprite;
    [SerializeField] Sprite playerSortSprite;
    [SerializeField] Sprite vipVehicleSprite;
    [SerializeField] Sprite SlotSprite;
    [SerializeField] Sprite SprGameOver;

    [SerializeField] GameObject panel;
    [SerializeField] GameObject background;
    [SerializeField] Button panelCloseButton;
    [SerializeField] Button useWithCoinsButton;
    [SerializeField] Button useWithAdsButton;
    public Button btn_ShuffleVehicles;
    public Button btn_ShufflePlayers;
    public Button btn_VipPlayers;

    public GameObject notEnoughCoinsPopup;
    [SerializeField] List<DataTextOfSkill> dataTextOfSkills;

    private bool isPanelClosed = false;
    private bool isInfoPlaying = false;
    public bool isUseSkillVip = false;
    private bool isShowGameOver = false;

    Action currentCallback = null;

    private void Start()
    {
        instance = this;
        InitializeUI();
        OnEndSkkillGame(TYPE_ITEM.CHANG_CAR, false);
        OnEndSkkillGame(TYPE_ITEM.CHANGE_PLAYER, false);
        OnEndSkkillGame(TYPE_ITEM.VIP, false);


        btn_ShuffleVehicles.onClick.AddListener(() =>
        {
            if(HelperManager.GetNumUseItemOfSkill(TYPE_ITEM.CHANG_CAR) > 0)
            {
                OnSkillChangeCar();
                OnEndSkkillGame(TYPE_ITEM.CHANG_CAR, true);
            }
            else
            {
                LoadDataGame.Instance.IsPause = true;
                ShowCarShufflePanel();
                Audio.Play(ScStatic.SFX_BUTTONSOUND);
                Vibration.Vibrate(30);
            }
           
        });
        btn_ShufflePlayers.onClick.AddListener(() =>
        {
            if (HelperManager.GetNumUseItemOfSkill(TYPE_ITEM.CHANGE_PLAYER) > 0)
            {
                OnSkillChangePlayer();
                OnEndSkkillGame(TYPE_ITEM.CHANGE_PLAYER, true);
            }
            else
            {
                LoadDataGame.Instance.IsPause = true;
                ShowPlayerSortPanel();
                Audio.Play(ScStatic.SFX_BUTTONSOUND);
                Vibration.Vibrate(30);
            }
        });

        btn_VipPlayers.onClick.AddListener(() =>
        {
            if (HelperManager.GetNumUseItemOfSkill(TYPE_ITEM.VIP) > 0)
            {
                OnSkillChangeVip();
                OnEndSkkillGame(TYPE_ITEM.VIP, true);
            }
            else
            {
                LoadDataGame.Instance.IsPause = true;
                ShowPoupSkillVip();
                Audio.Play(ScStatic.SFX_BUTTONSOUND);
                Vibration.Vibrate(30);
            }
           
        });
        panelCloseButton.onClick.AddListener(() =>
        {
            ClosePanel();
            Audio.Play(ScStatic.SFX_BUTTONSOUND);
            Vibration.Vibrate(30);

            if(isShowGameOver)
            {
                isShowGameOver = false;
                ShowOver();
            }
        });
    }

    public void ShowPoupRemoveSlot(ParkingSlots parkingSlot)
    {
        LoadDataGame.Instance.IsPause = true;

        Audio.Play(ScStatic.SFX_BUTTONSOUND);
        txtCoin.text = MoreSlot.ToString();
        useWithCoinsButton.interactable = HelperManager.DataPlayer.TotalCoin >= MoreSlot;
        SetPowerUpPanel(PowerUp.Slot, "More Slot", "Unlock a parking place", SlotSprite);
        useWithCoinsButton.onClick.AddListener(() => UsePowerUpWithCoins(MoreSlot, () => {
            LoadDataGame.Instance.IsPause = false;
            OnSlotSucess();
            parkingSlot.OnAdsSucess();
        }));

        currentCallback = () => {
            LoadDataGame.Instance.IsPause = false;
            OnSlotSucess();
            parkingSlot.OnAdsSucess();
        };
    }    

    private void OnSlotSucess()
    {
        this.StartCoroutine(onEnablePause());
        ClosePanel();
        Vibration.Vibrate(30);

    }

    public void ShowGameOver()
    {
        var slot = ParkingManager.instance.GetItemAds();
        LoadDataGame.Instance.IsPause = true;

        if (slot == null)
        {
            ShowOver();
        }
        else
        {
            isShowGameOver = true;
            txtCoin.text = GameOverSlot.ToString();

            currentCallback = () => {
                GameManager.instance.gameOver = false;
                isShowGameOver = false;
                this.StartCoroutine(onEnablePause());
                ClosePanel();
                Vibration.Vibrate(30);
                slot.OnAdsSucess();
            };

            useWithCoinsButton.interactable = HelperManager.DataPlayer.TotalCoin >= GameOverSlot;
            SetPowerUpPanel(PowerUp.gameOver, "Continue", "Get a new <color=green>parking space</color> to keep playing", SprGameOver);
            useWithCoinsButton.onClick.AddListener(() => UsePowerUpWithCoins(GameOverSlot, () => {
                GameManager.instance.gameOver = false;
                isShowGameOver = false;
                this.StartCoroutine(onEnablePause());
                ClosePanel();
                Vibration.Vibrate(30);
                slot.OnAdsSucess();
            }));
        }
    }

    private void ShowOver()
    {
        UiManager.instance.TogglePanel(UiManager.instance.gameOverPanle, true);
    }

    public void OnSkillTrain()
    {
        isUseSkillVip = true;
    }

    public void OnCallbackSucess()
    {
        currentCallback?.Invoke();
        currentCallback = null;
    }    

    private void InitializeUI()
    {
        panel.SetActive(false);
        background.SetActive(false);
        panel.transform.localScale = Vector3.zero;
        notEnoughCoinsPopup.transform.localScale = Vector3.zero;
    }

    private void ShowPoupSkillVip()
    {
        txtCoin.text = VipPlayerCost.ToString();

        useWithCoinsButton.interactable = HelperManager.DataPlayer.TotalCoin >= VipPlayerCost;
        SetPowerUpPanel(PowerUp.Vip, "Vip", "Choose <color=green>any car</color> to move to  <color=green>VIP</color> parking space", vipVehicleSprite);
        useWithCoinsButton.onClick.AddListener(() => UsePowerUpWithCoins(VipPlayerCost, OnSkillChangeVip));

        currentCallback = () => {
            OnSkillChangeVip();
        };
       
    }

    private void OnSkillChangeVip()
    {
        this.StartCoroutine(onEnablePause());
        ClosePanel();
        OnSkillTrain();
        Audio.Play(ScStatic.SFX_BUTTONSOUND);
        Vibration.Vibrate(30);
    }


    private void ShowCarShufflePanel()
    {
        txtCoin.text = shuffleCarCost.ToString();

        useWithCoinsButton.interactable = HelperManager.DataPlayer.TotalCoin >= shuffleCarCost;

        SetPowerUpPanel(PowerUp.ShuffleCar, "Shuffle", "Rearrange the <color=green>COLOR</color> of the Vehicles in the parking lot", carShuffleSprite);
        useWithCoinsButton.onClick.AddListener(() => UsePowerUpWithCoins(shuffleCarCost, OnSkillChangeCar));

        currentCallback = () => {
            OnSkillChangeCar();
        };
        
    }

    private void OnSkillChangeCar()
    {
        this.StartCoroutine(onEnablePause());
        ClosePanel();
        VehicleController.instance.RandomVehicleColors();
        Audio.Play(ScStatic.SFX_BUTTONSOUND);
        Vibration.Vibrate(30);
    }

    private void ShowPlayerSortPanel()
    {
        txtCoin.text = sortPlayerCost.ToString();
        useWithCoinsButton.interactable = HelperManager.DataPlayer.TotalCoin >= sortPlayerCost;

        SetPowerUpPanel(PowerUp.SortPlayers, "Sort", "Sort the <color=green>PASSENGERS</color> according to Vehicle Colors", playerSortSprite);
        useWithCoinsButton.onClick.AddListener(() => UsePowerUpWithCoins(sortPlayerCost, ShufflePlayersPowerUp));

        currentCallback = () => {
            OnSkillChangePlayer();
        };
    }

    private void OnSkillChangePlayer()
    {
        this.StartCoroutine(onEnablePause());
        ClosePanel();
        ShufflePlayersPowerUp();
        Audio.Play(ScStatic.SFX_BUTTONSOUND);
        Vibration.Vibrate(30);
    }


    private IEnumerator onEnablePause()
    {
        yield return new WaitForSeconds(0.5f);
        LoadDataGame.Instance.IsPause = false;
    }

    private void SetPowerUpPanel(PowerUp powerUp, string titleText, string infoText, Sprite iconSprite)
    {
        currentPowerUp = powerUp;
        title.text = titleText;
        info.text = infoText;
        icon.sprite = iconSprite;
        icon.SetNativeSize();
        OpenPanel();
    }

    private void OpenPanel()
    {
        openTween?.Kill();
        panel.SetActive(true);
        background.SetActive(true);
        closeTween = panel.transform.DOScale(Vector3.one, 0.3f);
    }
    Tween openTween;
    Tween closeTween;
    private void ClosePanel()
    {
        if (isPanelClosed)
            return;
        LoadDataGame.Instance.IsPause = false;
        isPanelClosed = true;
        closeTween?.Kill();
        ResetButtonListeners();
        background.SetActive(false);
        openTween = panel.transform.DOScale(Vector3.zero, 0.3f).OnComplete(() =>
        {
            isPanelClosed = false;
            panel.SetActive(false);
        });
    }

    private void UsePowerUpWithCoins(int cost, System.Action powerUpAction)
    {
        int coins = CoinsManager.Instance.GetTotalCoins();
        if (coins >= cost)
        {
            CoinsManager.Instance.DeductCoins(cost);
            ClosePanel();
            powerUpAction.Invoke();
        }
        else
        {
            PlayInfoPopup("Not Enough Coins!");
            return;
        }
        Audio.Play(ScStatic.SFX_BUTTONSOUND);
        Vibration.Vibrate(30);
    }

    private void ShufflePlayersPowerUp()
    {
        var cars = new List<Vehicle>(ParkingManager.instance.parkedVehicles);
        var players = PlayerManager.instance.playersInScene;
        int totalRemainingSeats = cars.Sum(car => car.SeatCount - car.playersInSeat);

        if (totalRemainingSeats < 24)
        {
            var additionalCars = VehicleController.instance.vehicles
                                .Where(car => !car.CheckForObstacles())
                                .ToList();

            foreach (var car in additionalCars)
            {
                cars.Add(car);
                totalRemainingSeats += car.SeatCount - car.playersInSeat;
                if (totalRemainingSeats >= 24) break;
            }
        }

        int playersMatched = 0;
        for (int i = 0; i < cars.Count && playersMatched < 24; i++)
        {
            int remainingSeats = cars[i].SeatCount - cars[i].playersInSeat;
            for (int j = playersMatched; j < players.Count && remainingSeats > 0 && playersMatched < 24; j++)
            {
                if (cars[i].vehicleColor == players[j].color)
                {
                    SwapPlayerColors(playersMatched, j);
                    playersMatched++;
                    remainingSeats--;
                }
            }
        }

        if (!PlayerManager.instance.isColormatched)
            EventManager.OnNewVehArrived?.Invoke();
    }


    private void SwapPlayerColors(int playerIndex1, int playerIndex2)
    {
        var players = PlayerManager.instance.playersInScene;
        var tempColor = players[playerIndex1].color;
        players[playerIndex1].ChangeColor(players[playerIndex2].color);
        players[playerIndex2].ChangeColor(tempColor);
    }

    private void PlayInfoPopup(string message)
    {
        if (isInfoPlaying)
            return;

        isInfoPlaying = true;
        var infoText = notEnoughCoinsPopup.GetComponent<TextMeshProUGUI>();
        infoText.text = message;
        notEnoughCoinsPopup.transform.DOScale(Vector3.one, 0.2f);
        DOVirtual.DelayedCall(2f, () =>
        {
            notEnoughCoinsPopup.transform.DOScale(Vector3.zero, 0.2f).OnComplete(() => isInfoPlaying = false);
        });
        Audio.Play(ScStatic.SFX_NOCOIN_SOUND);
        Vibration.Vibrate(30);
    }
    private void ResetButtonListeners()
    {
        useWithCoinsButton.onClick.RemoveAllListeners();
    }

    public void OnEndSkkillGame(TYPE_ITEM type, bool isAdd)
    {
        if(isAdd)
        {
            HelperManager.UpdateItemForSkill(type, -1);
        }
        foreach (var it in dataTextOfSkills)
        {
            if(it.type.Equals(type))
            {
                int numItem = HelperManager.GetNumUseItemOfSkill(type);
                it.txtSkill.text = numItem <= 0 ? "+" : numItem.ToString();
               
            }
        }
    }
}

public enum PowerUp
{
    None,
    ShuffleCar,
    SortPlayers,
    Vip,
    Slot,
    gameOver
}