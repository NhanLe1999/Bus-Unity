using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Reflection;
using Cysharp.Threading.Tasks;


namespace MobileMonetizationPro
{
    public class MobileMonetizationPro_LevelPlayManager : MonoBehaviour
    {
        public Button ShowBannerAdButton;

        [Serializable]
        public class FunctionInfo
        {
            public Button RewardedButton;
            public CallbackAds callbackAds;
            public GameObject objNotButton;
        }

        private List<Button> ActionButtonsToInvokeInterstitalAds  = new();

        private List<Button> rewardedButtons = new List<Button>();

        private List<GameObject> rewardedGameObject = new ();


        public List<FunctionInfo> functions = new List<FunctionInfo>();

        FunctionInfo functionInfo;

        public bool isShowBanner = false;

        public static MobileMonetizationPro_LevelPlayManager instance = null;

        private void OnValidate()
        {
           
        }
        public List<Button> GetRewardedButtons()
        {
            foreach (var functionInfo in functions)
            {
                if(functionInfo.RewardedButton == null)
                {
                    continue;
                }
                rewardedButtons.Add(functionInfo.RewardedButton);
            }
            return rewardedButtons;
        }

        public List<GameObject> GetRewardedGameObject()
        {
            foreach (var functionInfo in functions)
            {
                if(functionInfo.objNotButton == null)
                {
                    continue;
                }
                rewardedGameObject.Add(functionInfo.objNotButton);
            }
            return rewardedGameObject;
        }

        public void OnButtonClick()
        {
            if (functionInfo != null)
            {
                functionInfo.callbackAds?.OnCallbackAds();
            }
        }
        private List<string> GetFunctionNames(MonoBehaviour script)
        {
            List<string> functionNames = new List<string>();
            if (script != null)
            {
                Type type = script.GetType();
                MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
                foreach (MethodInfo method in methods)
                {
                    functionNames.Add(method.Name);
                }
            }
            return functionNames;
        }

        private void OnDestroy()
        {
            instance = null;
        }

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            MobileMonetizationPro_LevelPlayInitializer.instance?.LoadRewarded();

            if (PlayerPrefs.GetInt("AdsRemoved") == 0)
            {
                if (isShowBanner)
                {
                    if (MobileMonetizationPro_LevelPlayInitializer.instance != null)
                    {
                        MobileMonetizationPro_LevelPlayInitializer.instance.LoadBanner();
                    }
                }
            }

            List<Button> rewardedButtons = GetRewardedButtons();

            foreach (Button rewardedButton in rewardedButtons)
            {
                if(rewardedButton != null)
                {
                    rewardedButton.onClick.AddListener(() => ShowRewarded(rewardedButton, null));
                }
            }
        }

        public void EnableBtnShowAds()
        {

        }

        private void OnEnable()
        {
            if (PlayerPrefs.GetInt("AdsRemoved") == 0)
            {
                //Add AdInfo Banner Events
                IronSourceBannerEvents.onAdLoadedEvent += BannerOnAdLoadedEvent;
                IronSourceBannerEvents.onAdLoadFailedEvent += BannerOnAdLoadFailedEvent;
                IronSourceBannerEvents.onAdClickedEvent += BannerOnAdClickedEvent;
                IronSourceBannerEvents.onAdScreenPresentedEvent += BannerOnAdScreenPresentedEvent;
                IronSourceBannerEvents.onAdScreenDismissedEvent += BannerOnAdScreenDismissedEvent;
                IronSourceBannerEvents.onAdLeftApplicationEvent += BannerOnAdLeftApplicationEvent;

                //Add AdInfo Interstitial Events
                IronSourceInterstitialEvents.onAdReadyEvent += InterstitialOnAdReadyEvent;
                IronSourceInterstitialEvents.onAdLoadFailedEvent += InterstitialOnAdLoadFailed;
                IronSourceInterstitialEvents.onAdOpenedEvent += InterstitialOnAdOpenedEvent;
                IronSourceInterstitialEvents.onAdClickedEvent += InterstitialOnAdClickedEvent;
                IronSourceInterstitialEvents.onAdShowSucceededEvent += InterstitialOnAdShowSucceededEvent;
                IronSourceInterstitialEvents.onAdShowFailedEvent += InterstitialOnAdShowFailedEvent;
                IronSourceInterstitialEvents.onAdClosedEvent += InterstitialOnAdClosedEvent;
            }
                //Add AdInfo Rewarded Video Events
                IronSourceRewardedVideoEvents.onAdOpenedEvent += RewardedVideoOnAdOpenedEvent;
                IronSourceRewardedVideoEvents.onAdClosedEvent += RewardedVideoOnAdClosedEvent;
                IronSourceRewardedVideoEvents.onAdAvailableEvent += RewardedVideoOnAdAvailable;
                IronSourceRewardedVideoEvents.onAdUnavailableEvent += RewardedVideoOnAdUnavailable;
                IronSourceRewardedVideoEvents.onAdShowFailedEvent += RewardedVideoOnAdShowFailedEvent;
                IronSourceRewardedVideoEvents.onAdRewardedEvent += RewardedVideoOnAdRewardedEvent;
                IronSourceRewardedVideoEvents.onAdClickedEvent += RewardedVideoOnAdClickedEvent;
        }


        public void ShowInterstitial()
        {

            if (PlayerPrefs.GetInt("AdsRemoved") == 0)
            {
                if (MobileMonetizationPro_LevelPlayInitializer.instance != null)
                {
                    if (MobileMonetizationPro_LevelPlayInitializer.instance.EnableTimedInterstitalAds == false)
                    {
                        if (IronSource.Agent.isInterstitialReady())
                        {
                            IronSource.Agent.showInterstitial();
                            Debug.Log("ads_hehe_showInterstitial_sucess");
                        }
                        else
                        {
                            MobileMonetizationPro_LevelPlayInitializer.instance.LoadInterstitial();
                            Debug.Log("ads_hehe_showInterstitial_error");
                        }
                    }
                    else
                    {

                        if (MobileMonetizationPro_LevelPlayInitializer.instance.CanShowAdsNow == true)
                        {
                            if (IronSource.Agent.isInterstitialReady())
                            {
                                IronSource.Agent.showInterstitial();
                                Debug.Log("ads_hehe_showInterstitial_sucess");
                            }
                            else
                            {
                                MobileMonetizationPro_LevelPlayInitializer.instance.LoadInterstitial();
                                Debug.Log("ads_hehe_showInterstitial_error");
                            }
                        }
                    }
                }
            }
        }
        /************* Banner AdInfo Delegates *************/
        //Invoked once the banner has loaded
        void BannerOnAdLoadedEvent(IronSourceAdInfo adInfo)
        {
            
        }
        //Invoked when the banner loading process has failed.
        void BannerOnAdLoadFailedEvent(IronSourceError ironSourceError)
        {
            Debug.Log("ads_hehe_LoadBanner_Failed");
        }
        // Invoked when end user clicks on the banner ad
        void BannerOnAdClickedEvent(IronSourceAdInfo adInfo)
        {
        }
        //Notifies the presentation of a full screen content following user click
        void BannerOnAdScreenPresentedEvent(IronSourceAdInfo adInfo)
        {
        }
        //Notifies the presented screen has been dismissed
        void BannerOnAdScreenDismissedEvent(IronSourceAdInfo adInfo)
        {
        }
        //Invoked when the user leaves the app
        void BannerOnAdLeftApplicationEvent(IronSourceAdInfo adInfo)
        {
        }
        /************* Interstitial AdInfo Delegates *************/
        // Invoked when the interstitial ad was loaded succesfully.
        void InterstitialOnAdReadyEvent(IronSourceAdInfo adInfo)
        {
        }
        // Invoked when the initialization process has failed.
        void InterstitialOnAdLoadFailed(IronSourceError ironSourceError)
        {
        }
        // Invoked when the Interstitial Ad Unit has opened. This is the impression indication. 
        void InterstitialOnAdOpenedEvent(IronSourceAdInfo adInfo)
        {

        }
        // Invoked when end user clicked on the interstitial ad
        void InterstitialOnAdClickedEvent(IronSourceAdInfo adInfo)
        {
        }
        // Invoked when the ad failed to show.
        void InterstitialOnAdShowFailedEvent(IronSourceError ironSourceError, IronSourceAdInfo adInfo)
        {
            if (MobileMonetizationPro_LevelPlayInitializer.instance != null)
            {
                MobileMonetizationPro_LevelPlayInitializer.instance.LoadInterstitial();
            }
        }
        // Invoked when the interstitial ad closed and the user went back to the application screen.
        void InterstitialOnAdClosedEvent(IronSourceAdInfo adInfo)
        {
            if (MobileMonetizationPro_LevelPlayInitializer.instance != null)
            {
                if (MobileMonetizationPro_LevelPlayInitializer.instance.EnableTimedInterstitalAds == true)
                {
                    MobileMonetizationPro_LevelPlayInitializer.instance.CanShowAdsNow = false;
                    MobileMonetizationPro_LevelPlayInitializer.instance.Timer = 0f;
                }

                MobileMonetizationPro_LevelPlayInitializer.instance.LoadInterstitial();
            }
        }
        // Invoked before the interstitial ad was opened, and before the InterstitialOnAdOpenedEvent is reported.
        // This callback is not supported by all networks, and we recommend using it only if  
        // it's supported by all networks you included in your build. 
        void InterstitialOnAdShowSucceededEvent(IronSourceAdInfo adInfo)
        {
        }

        public void ShowRewarded(Button clickedButton, GameObject objNotButton)
        {
            if (PlayerPrefs.GetInt("AdsRemoved", 0) == 1)
            {
                GetFunctionInfor(clickedButton, objNotButton);
                OnButtonClick();
                return;
            }

#if UNITY_EDITOR
            GetFunctionInfor(clickedButton, objNotButton);
            OnButtonClick();
            return;
#endif

            if (!CheckNetwork.Instance.IsConnect)
            {
                UINoNetworkCanvas.Show();
                return;
            }

            ScStatic.IsUseAdsOpenApp = false;

            if (MobileMonetizationPro_LevelPlayInitializer.instance != null)
            {
                if (IronSource.Agent.isRewardedVideoAvailable())
                {
                    GetFunctionInfor(clickedButton, objNotButton);
                    MobileMonetizationPro_LevelPlayInitializer.instance.isLoadReward = true;
                    IronSource.Agent.showRewardedVideo();
                }
                else
                {
                    MobileMonetizationPro_LevelPlayInitializer.instance.LoadRewarded();
                }
            }
        }

        private void GetFunctionInfor(Button clickedButton, GameObject objNotButton)
        {
            if (clickedButton != null)
            {
                functionInfo = functions.Find(info => info.RewardedButton == clickedButton);
            }

            if (objNotButton != null)
            {
                functionInfo = functions.Find(info => info.objNotButton == objNotButton);
            }
        }

        async void ResetStateShowAdsOpen()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(0.5f)); ;
            ScStatic.IsUseAdsOpenApp = true;
        }


        /************* RewardedVideo AdInfo Delegates *************/
        // Indicates that there’s an available ad.
        // The adInfo object includes information about the ad that was loaded successfully
        // This replaces the RewardedVideoAvailabilityChangedEvent(true) event
        void RewardedVideoOnAdAvailable(IronSourceAdInfo adInfo)
        {
        }
        // Indicates that no ads are available to be displayed
        // This replaces the RewardedVideoAvailabilityChangedEvent(false) event
        void RewardedVideoOnAdUnavailable()
        {
        }
        // The Rewarded Video ad view has opened. Your activity will loose focus.
        void RewardedVideoOnAdOpenedEvent(IronSourceAdInfo adInfo)
        {
            ResetStateShowAdsOpen();
            Audio.Pause();
            Audio.PauseBackgroundMusic();
          //  LogicGame.Instance?.SetStateGame(StateGame.Pause);
        }
        // The Rewarded Video ad view is about to be closed. Your activity will regain its focus.
        void RewardedVideoOnAdClosedEvent(IronSourceAdInfo adInfo)
        {
            ResetStateShowAdsOpen();
            Audio.Resume();
            Audio.ResumeBackgroundMusic();
         //   LogicGame.Instance?.OnRevertStateGame();
            if (MobileMonetizationPro_LevelPlayInitializer.instance != null)
            {
                if (MobileMonetizationPro_LevelPlayInitializer.instance.ResetInterstitalAdTimerOnRewardedAd == true)
                {
                    MobileMonetizationPro_LevelPlayInitializer.instance.CanShowAdsNow = false;
                    MobileMonetizationPro_LevelPlayInitializer.instance.Timer = 0f;
                }
                MobileMonetizationPro_LevelPlayInitializer.instance.LoadRewarded();
            }


        }
        // The user completed to watch the video, and should be rewarded.
        // The placement parameter will include the reward data.
        // When using server-to-server callbacks, you may ignore this event and wait for the ironSource server callback.
        void RewardedVideoOnAdRewardedEvent(IronSourcePlacement placement, IronSourceAdInfo adInfo)
        {
            ResetStateShowAdsOpen();
            //rewardedButton.onClick.AddListener(() => OnButtonClick(rewardedButton));
            OnButtonClick();
        }
        // The rewarded video ad was failed to show.
        void RewardedVideoOnAdShowFailedEvent(IronSourceError error, IronSourceAdInfo adInfo)
        {
            ResetStateShowAdsOpen();
            Audio.Resume();
            Audio.ResumeBackgroundMusic();
          //  LogicGame.Instance?.OnRevertStateGame();
        }
        // Invoked when the video ad was clicked.
        // This callback is not supported by all networks, and we recommend using it only if
        // it’s supported by all networks you included in your build.
        void RewardedVideoOnAdClickedEvent(IronSourcePlacement placement, IronSourceAdInfo adInfo)
        {
        }
    }
}