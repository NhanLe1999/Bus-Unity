using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitScene : MonoBehaviour
{
    [SerializeField] UILoadingCanvas uILoadingCanvas = null;

    void Start()
    {
        this.StartCoroutine(RunSpeed());
        Vibration.Init();
        Logic.Instance.Init();
        LoadData();
    }

    async void LoadData()
    {
        while (true)
        {
            if (uILoadingCanvas.CountCurrent < 1.0f)
            {
                await UniTask.Yield();
            }
            else
            {
                HelperManager.OnLoadScene(ScStatic.HOME_SCENE);
                break;
            }
        }
    }

    IEnumerator RunSpeed()
    {
        yield return new WaitForSeconds(0.02f);
        uILoadingCanvas.AutoLoad(0.01f);
        yield return new WaitForSeconds(0.008f);
        this.StartCoroutine(RunSpeed());
    }

}
