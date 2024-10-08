using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Ump.Api;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MobileMonetizationPro
{
    public class MobileMonetizationPro_LevelPlayInitializer : MonoBehaviour
    {
        public static MobileMonetizationPro_LevelPlayInitializer instance;

        public bool EnableGdprConsentMessage = true;

        [Header("App Key's")]
        public string AndroidAppKey = "";
        public string IOSAppKey = "";

        [Header("App Key Test's")]
        public bool IsEnableIdTest = false;
        public string AndroidAppKeyTest = "";
        public string IOSAppKeyTest = "";

        [Header("Ad Settings")]
        public bool ShowBannerAdsInStart = true;
        public IronSourceBannerPosition ChooseBannerPosition = IronSourceBannerPosition.BOTTOM;
        public enum BannerSize
        {
            BANNER,
            LARGE,
            RECTANGLE,
            SMART
        }
        public BannerSize ChooseBannerSize = BannerSize.BANNER;
        public bool EnableTimedInterstitalAds = true;
        public int InterstitialAdIntervalSeconds = 10;
        public bool ResetInterstitalAdTimerOnRewardedAd = true;
        [HideInInspector]
        public bool CanShowAdsNow = false;
        [HideInInspector]
        public float Timer = 0;
        [HideInInspector]
        public bool IsBannerStartShowing = false;
        [HideInInspector]
        public bool IsAdsInitializationCompleted = false;

        public bool isLoadReward = false;
        public bool isShowInterstitia = false;

        private void Awake()
        {

            if(Debug.isDebugBuild)
            {
                AndroidAppKey = AndroidAppKeyTest;
                IOSAppKey = IOSAppKeyTest;
            }

            Debug.Log("nenn" + AndroidAppKey + "\n" + IOSAppKey);

            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                // If an instance already exists, destroy this duplicate
                Destroy(gameObject);
            }
        }
        private void OnEnable()
        {

            if (EnableGdprConsentMessage == true)
            {
                // Create a ConsentRequestParameters object.
                ConsentRequestParameters request = new ConsentRequestParameters();

                // Check the current consent information status.
                ConsentInformation.Update(request, OnConsentInfoUpdated);
            }
            else
            {
                IronSourceEvents.onSdkInitializationCompletedEvent += SdkInitialized;
            }
        }
        private void Start()
        {
            IronSource.Agent.validateIntegration();
#if UNITY_ANDROID
            IronSource.Agent.init(AndroidAppKey);
#elif UNITY_IPHONE
            IronSource.Agent.init(IOSAppKey);
#else
    string appKey = "unexpected_platform";
#endif
            IronSource.Agent.setManualLoadRewardedVideo(true);
        }
        void OnConsentInfoUpdated(FormError consentError)
        {
            if (consentError != null)
            {
                // Handle the error.
                UnityEngine.Debug.LogError(consentError);
                return;
            }

            // If the error is null, the consent information state was updated.
            // You are now ready to check if a form is available.
            ConsentForm.LoadAndShowConsentFormIfRequired((FormError formError) =>
            {
                if (formError != null)
                {
                    // Consent gathering failed.
                    UnityEngine.Debug.LogError(consentError);
                    return;
                }

                // Consent has been gathered.
                if (ConsentInformation.CanRequestAds())
                {
                    IronSourceEvents.onSdkInitializationCompletedEvent += SdkInitialized;
                    LoadBanner();
                    LoadInterstitial();
                    LoadRewarded();
                }
            });

        }
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (IsAdsInitializationCompleted == true)
            {
                Debug.Log("ads_neee_OnSceneLoaded_sucess");
                LoadInterstitial();
                LoadRewarded();
            }
            else
            {
                Debug.Log("ads_neee_OnSceneLoaded_error");
            }

        }
        void SdkInitialized()
        {
            print("Sdk in initialized!!");
            Debug.Log("ads_neee_initialized_sucess");
            IsAdsInitializationCompleted = true;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        void OnApplicationPause(bool isPaused)
        {
            IronSource.Agent.onApplicationPause(isPaused);
        }

        public void LoadBanner()
        {
            if (PlayerPrefs.GetInt("AdsRemoved") == 0)
            {
                Debug.Log("Banner showing");
                if (ChooseBannerSize == BannerSize.SMART)
                {
                    IronSource.Agent.loadBanner(IronSourceBannerSize.SMART, ChooseBannerPosition);
                }
                else if (ChooseBannerSize == BannerSize.RECTANGLE)
                {
                    IronSource.Agent.loadBanner(IronSourceBannerSize.RECTANGLE, ChooseBannerPosition);
                }
                else if (ChooseBannerSize == BannerSize.LARGE)
                {
                    IronSource.Agent.loadBanner(IronSourceBannerSize.LARGE, ChooseBannerPosition);
                }
                else
                {
                    IronSource.Agent.loadBanner(IronSourceBannerSize.BANNER, ChooseBannerPosition);
                }
                IsBannerStartShowing = true;
            }

        }
        public void DestroyBanner()
        {
            IronSource.Agent.hideBanner();
        }

        public void LoadInterstitial()
        {
            if (PlayerPrefs.GetInt("AdsRemoved") == 0)
            {
                if (IronSource.Agent.isInterstitialReady())
                {
                    isShowInterstitia = true;
                }
                
                if(!isShowInterstitia)
                {
                    IronSource.Agent.loadInterstitial();
                }
            }
        }
        public void LoadRewarded()
        {
            if (IronSource.Agent.isRewardedVideoAvailable())
            {
                isLoadReward = true;
            }

            if (!isLoadReward)
            {
                IronSource.Agent.loadRewardedVideo();
                Debug.Log("ads_hehe_loadw_video_sucess");
            }
            else
            {
                Debug.Log("ads_hehe_khong_load_nua_video_sucess");
            }
        }

        private void Update()
        {
            if (PlayerPrefs.GetInt("AdsRemovedSuccessfully") == 0)
            {
                if (Timer >= InterstitialAdIntervalSeconds)
                {
                    Timer = 0;
                    CanShowAdsNow = true;
                }
                else
                {
                    if (EnableTimedInterstitalAds == true)
                    {
                        Timer += Time.deltaTime;
                        if (PlayerPrefs.GetInt("AdsRemoved") == 1)
                        {
                            if (PlayerPrefs.GetInt("AdsRemovedSuccessfully") == 0)
                            {
                                IronSource.Agent.destroyBanner();
                                PlayerPrefs.SetInt("AdsRemovedSuccessfully", 1);
                            }
                        }
                    }
                }
            }
        }
    }
}