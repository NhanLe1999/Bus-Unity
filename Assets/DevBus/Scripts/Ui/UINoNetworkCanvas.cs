using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

#if UNITY_ANDROID
#endif

public class UINoNetworkCanvas : Dialog<UINoNetworkCanvas>
{
    public static bool isShow = false;
    [SerializeField] GameObject objBtnOke = null;

    public Action callbackNetwork = null;

    private bool ischecking = false;


    public static void Show()
    {
        /*if (!isShow)
        {
            isShow = true;
            currentState = GameManager.instance.currentState;
            // GameManager.instance.OnStateChange(GameManager.gameState.Network);

            if (LogicGame.Instance != null)
            {
                LogicGame.Instance.SetStateGame(StateGame.Pause);
            }

            Open();
        }*/
        Open();
    }

    private void OnEnable()
    {
       // isShow = true;
       // CheckNetwork.Instance.StopCheck();
    }

    private void OnDisable()
    {
       // isShow = false;
      //  CheckNetwork.Instance.BeginCheck();
    }

    public static void Hide()
    {
       /* isShow = false;
        if (LogicGame.Instance != null)
        {
            LogicGame.Instance.OnRevertStateGame();
        }*/

        Close();
    }

    public void OnClose()
    {
        Hide();
        /*if(ischecking)
        {
            return;
        }

        this.StartCoroutine(OnCheckClose());*/
    }

}
