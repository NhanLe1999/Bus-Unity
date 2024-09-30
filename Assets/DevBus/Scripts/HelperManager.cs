using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class HelperManager
{
    private static DataPlayer _dataPlayer = null;

    public static DataPlayer DataPlayer
    {
        get
        {
            if (_dataPlayer == null)
            {
                StorageHandler storageHandler = new StorageHandler();

                if (storageHandler.IsExitKey(ScStatic.PLAYERDATA))
                {
                    _dataPlayer = storageHandler.LoadData<DataPlayer>(ScStatic.PLAYERDATA);
                }

                if (_dataPlayer == null)
                {
                    _dataPlayer = new DataPlayer();

                    Save();
                }
            }

            return _dataPlayer;
        }
        set
        {
            _dataPlayer = value;
        }
    }

    public static void Save()
    {
        var storage = new StorageHandler();
        storage.SaveData<DataPlayer>(ScStatic.PLAYERDATA, DataPlayer);
    }

    #region LOAD_SCENE
    public static void OnLoadScene(string scene, LoadSceneMode mode = LoadSceneMode.Single)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene, mode);
    }

    #endregion


}
