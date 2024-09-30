using UnityEngine;

public class Singleton<Class> : MonoBehaviour where Class : MonoBehaviour
{
    private static Class instance;

    public static Class Instance
    {
        get
        {
            return instance;
        }
    }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as Class;
        }
    }
}

/// <summary>
/// Singleton mono alway exist through all screnes. 
/// </summary>
public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static bool IsInstanceInvalid()
    {
        return instance != null;
    }
    // IsInstanceInvalid()

    //void Awake() {
    //    singleton = gameObject.GetComponent<T>();
    //    DontDestroyOnLoad(this);
    //} // Awake ()

    public static T Instance
    {
        get
        {
            if (instance != null)
                return instance;

            instance = FindObjectOfType<T>();

            if (instance != null)
                return instance;
#if UNITY_EDITOR
            //Debug.LogError($"Not found Object for type {typeof(T).Name}");
#endif
            return instance;
        }


    } // Instance

}// SingletonMono