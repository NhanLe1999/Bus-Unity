using UnityEngine;
using UnityEngine.Events;

public class CallbackAds : MonoBehaviour
{
    public UnityEvent callbackAds;

    public void OnCallbackAds()
    {
        callbackAds?.Invoke();
    }
}
