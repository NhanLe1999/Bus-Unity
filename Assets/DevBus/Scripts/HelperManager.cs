using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
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
                    _dataPlayer.DataNumSkillGame = SetDataStartSkillGame();

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


    public static Vector2 GetSizeOfCanvas(Canvas canvas)
    {
        RectTransform canvasRect = canvas.GetComponent<RectTransform>();
        float width = canvasRect.rect.width;
        float height = canvasRect.rect.height;
        return new Vector2(width, height);
    }

    private static List<DataNumSkillGame> SetDataStartSkillGame()
    {
        //when test game item value =9999;
        var numCountUse = 1;
        List<DataNumSkillGame> listData = new List<DataNumSkillGame>();

        DataNumSkillGame datachangeCar = new DataNumSkillGame();
        datachangeCar.typeSkill = TYPE_ITEM.CHANG_CAR;
        datachangeCar.numCountUse = numCountUse;
        listData.Add(datachangeCar);

        DataNumSkillGame datachangPlayer = new DataNumSkillGame();
        datachangPlayer.typeSkill = TYPE_ITEM.CHANGE_PLAYER;
        datachangPlayer.numCountUse = numCountUse;
        listData.Add(datachangPlayer);

        DataNumSkillGame dataVip = new DataNumSkillGame();
        dataVip.typeSkill = TYPE_ITEM.VIP;
        dataVip.numCountUse = numCountUse;
        listData.Add(dataVip);

        return listData;
    }

    public static void UpdateItemForSkill(TYPE_ITEM type, int numAdd)
    {
        if (type == TYPE_ITEM.COIN)
        {
            DataPlayer.TotalCoin += numAdd;
            if(DataPlayer.TotalCoin  < 0)
            {
                DataPlayer.TotalCoin = 0;
            }
            return;
        }

        foreach(var data in DataPlayer.DataNumSkillGame)
        {
            if(data.typeSkill.Equals(type))
            {
                data.numCountUse += numAdd;

                if(data.numCountUse < 0)
                {
                    data.numCountUse = 0;
                }
            }
        }
    }

    public static int GetNumUseItemOfSkill(TYPE_ITEM type)
    {
        foreach (var data in DataPlayer.DataNumSkillGame)
        {
            if (data.typeSkill.Equals(type))
            {
                return data.numCountUse;
            }
        }
        return 0;
    }

    #region LOAD_SCENE
    public static void OnLoadScene(string scene, LoadSceneMode mode = LoadSceneMode.Single)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene, mode);
    }

    #endregion


}
