using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageHandler
{
    public void SaveData<T>(string fileName, T obj)
    {
        ES3.Save<T>(fileName, obj);
    }
    public T LoadData<T>(string fileName)
    {
        return ES3.Load<T>(fileName);
    }

    public bool IsExitKey(string fileName)
    {
        return ES3.KeyExists(fileName);
    }

    public void DeleteKey(string key)
    {
        if(!ES3.KeyExists(key))
        {
            return;
        }

        ES3.DeleteKey(key);
    }
}
