using System;
using System.Collections;
using DG.Tweening;
using TJ.Scripts;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public MaterialHolder vehMaterialHolder;
    public MaterialHolder stickmanMaterialHolder;
    public int winCount = 0;

    public bool gameOver = false;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        //MaterialHolder.InitializeMaterialDictionary();
    }

    private void Start()
    {
        Application.targetFrameRate = 120;
    }

    private bool IfSameColorVehicleParked()
    {
        var vehicles = ParkingManager.instance.parkedVehicles;
        if (vehicles.Count > 0 && PlayerManager.instance.activePlayerList.Count > 0)
        {
            foreach (var VARIABLE in vehicles)
            {
                if (VARIABLE.vehicleColor == PlayerManager.instance.activePlayerList[0].color)
                {
                    return true;
                }
            }
        }
        else if (vehicles.Count <= 0)
        {
            return true;
        }
        else if (PlayerManager.instance.activePlayerList.Count <= 0)
        {
            return true;
        }

        return false;
    }

    public bool ChekIfSlotFull(bool isShow)
    {
        var vehicles = ParkingManager.instance.parkedVehicles;
        if (vehicles.Count == ParkingManager.instance.slots.Count - 1)
        {
            if(isShow)
            {
                UiManager.instance.ShowPoupNoti("One Space Left!");
            }
            Debug.Log("<color=yellow>Warning: Only One Slot Left</color>");
        }

        if (vehicles.Count == ParkingManager.instance.slots.Count)
        {
            if(isShow)
            {
                UiManager.instance.ShowPoupNoti("Out Of Slot!");
            }
            return true;

        }
        return false;
    }

    public IEnumerator CheckIfGameOver()
    {
        yield return new WaitForSeconds(3f);
        if (ChekIfSlotFull(false) && IfSameColorVehicleParked() == false)
        {
            gameOver = true;
            Audio.Play(ScStatic.SFX_FAIL_SOUND);
            UiManager.instance.TogglePanel(UiManager.instance.gameOverPanle, true);
            Debug.Log("<color=red>Warning: Game Over</color>");
        }
    }

    private bool alreaduCalled;

    public void CheckGameWin()
    {
        if (alreaduCalled)
            return;

        winCount++;
        if (winCount == VehicleController.instance.totalVehicles)
        {
            alreaduCalled = true;

            HelperManager.DataPlayer.numWinLevel += 1;

            DOVirtual.DelayedCall(1.5f,
                () => {
                    HelperManager.DataPlayer.NumLevel++;
                //    HelperManager.OnLoadScene(ScStatic.GAME_SCENE);
                    Audio.Play(ScStatic.SFX_WIN_SOUND);
                });


            DOVirtual.DelayedCall(1.5f, () => Audio.Play(ScStatic.SFX_WIN_SOUND));
            
            DOVirtual.DelayedCall(2f, () => UiManager.instance.TogglePanel(UiManager.instance.winPanel, true));
            LevelManager.LevelProgressed();
            Debug.Log("<color=Green>Success: Game Win</color>");
        }
    }
}