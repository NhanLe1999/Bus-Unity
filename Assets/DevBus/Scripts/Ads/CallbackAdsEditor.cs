#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CallbackAds))]
public class CallbackAdsEditor : Editor
{
    public override void OnInspectorGUI()
    {
        CallbackAds callbackExample = (CallbackAds)target;
        DrawDefaultInspector();
    }
}
#endif