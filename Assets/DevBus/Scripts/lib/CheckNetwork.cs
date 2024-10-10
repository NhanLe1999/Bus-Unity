using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CheckNetwork : SingletonMono<CheckNetwork>
{
    private Coroutine _checkNetwork;

    private bool _isConnect = false;

    public bool IsConnect
    {
        get
        {
   /*         if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                return false;
            }
            else if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork)
            {
                return false;
            }
            else if (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork)
            {
                return true;
            }*/
          //  return false;
             return _isConnect;
        }
        set
        {
            _isConnect = value;
        }
    }

    private bool isReturn = false;
    public Action callbackNetwork = null;

    private bool isCallHttp = false;

    float timeDelay = 0;

    public int index = 0;


    void Start()
    {
        OnStartCheck();
    }

    public void OnStartCheck()
    {
        IsConnect = false;
        timeDelay = 0.0f;
        DontDestroyOnLoad(this.gameObject);
        StartCheck();
    }

    IEnumerator OnCheckNetwork()
    {
        yield return new WaitForSecondsRealtime(timeDelay);
        isCallHttp = true;
        CheckWifiInternet(onsucess =>
        {
            isCallHttp = false;

            IsConnect = onsucess;
            if (!onsucess)
            {
                //UINoNetworkCanvas.Show();
                timeDelay = 1.5f;
            }
            else
            {
                timeDelay = 5.0f;
            }
            index++;
        });

        yield return new WaitUntil(() => !isCallHttp);
        StartCheck();
    }

    private void StartCheck()
    {
        if (isReturn || isCallHttp)
        {
            return;
        }
        if (_checkNetwork != null)
        {
            this.StopCoroutine(_checkNetwork);
            _checkNetwork = null;
        }
        _checkNetwork = StartCoroutine(OnCheckNetwork());
    }

    public void StopCheck()
    {
        isReturn = true;
        this.StopCoroutine(_checkNetwork);
        _checkNetwork = null;
        isCallHttp = false;
    }

    public void BeginCheck()
    {
        if(isCallHttp)
        {
            return;
        }
        isReturn = false;
        StartCheck();
    }

    void CheckWifiInternet(System.Action<bool> onsucess)
    {
        this.StartCoroutine(CheckInternetConnect(onsucess));
    }
    IEnumerator CheckInternetConnect(System.Action<bool> action)
    {
        string uri = "https://www.google.com";
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            bool isSucess = false;
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                    break;
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError("Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError("HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    isSucess = true;
                    break;
            }

            action.Invoke(isSucess);
        }
    }
}
