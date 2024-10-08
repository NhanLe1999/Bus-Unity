using Firebase.Analytics;
//using Firebase.Crashlytics;
//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class FireBaseService : ITrackingService
{
    private bool inited = false;

  
    public void InitService()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
           
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                var app = Firebase.FirebaseApp.DefaultInstance;
                inited = true;
                // Set a flag here to indicate whether Firebase is ready to use by your app.
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }

           // Firebase.Messaging.FirebaseMessaging.TokenReceived += OnTokenReceived;
          //  Firebase.Messaging.FirebaseMessaging.MessageReceived += OnMessageReceived;

        });
        
    }

    public void LogEvent(string message)
    {
        if (!inited)
        {
            return;
        }
        FirebaseAnalytics.LogEvent(message);
    }

    public void LogEvent(string message, Dictionary<string, string> parameters)
    {
        if (!inited)
        {
            return;
        }

        Parameter[] parameterArray = new Parameter[parameters.Count];
        int index = 0;

        foreach (var param in parameters)
        {

            Parameter parameter = new Parameter(param.Key, param.Value.ToString());
            parameterArray[index] = parameter;
            index++;
        }

        FirebaseAnalytics.LogEvent(message, parameterArray);
    }
    

    public void HandleIAP(string productId, string price, string currency)
    {/*
        Dictionary<string, string> dict = new Dictionary<string, string>();
        dict[TrackingConst.PRODUCT_ID] = productId;
        dict[TrackingConst.PRICE] = price;
        dict[TrackingConst.CURRENCY] = currency;

        LogEvent(TrackingConst.IAP, dict);*/
    }

    public void ResourceChange(string key, string source, int amount)
    {
        /*var dict = new Dictionary<string, string>();
        dict[TrackingConst.RESOURCE_SOURCE] = source;
        dict[TrackingConst.RESOURCE_AMOUNT] = amount.ToString();

        LogEvent(key, dict);*/
    }

}
