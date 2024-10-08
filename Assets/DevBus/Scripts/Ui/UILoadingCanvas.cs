using Cysharp.Threading.Tasks.Linq;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILoadingCanvas : MonoBehaviour
{
    [SerializeField] private Image imgSlide;
    [SerializeField] TextMeshProUGUI textMesh = null;
    [SerializeField] RectTransform objBus = null;
    [SerializeField] RectTransform objBgImg = null;

    float SizeObj = 0.0f;

    public float CountCurrent = 0f;
    float countLoading = 0f;

    void Start()
    {
        SizeObj = objBgImg.sizeDelta.x - 50;
        imgSlide.fillAmount = 0;
    }

    public void SetSlide(float val)
    {
        imgSlide.fillAmount = val;
    }
    public void SetPercentLoad(float per)
    {
        if(per > 100.0f)
        {
            per = 100;
        }
    }

    public void AutoLoad(float time)
    {
        countLoading += time;
    }

    private void Update()
    {
        if(CountCurrent < countLoading)
        {
            CountCurrent += Time.deltaTime * 0.75f;
            var temp = CountCurrent / 1.0f;
            SetSlide(temp);
            SetPercentLoad(Mathf.RoundToInt(temp * 100f));
        }

        if(CountCurrent <= 1.0f)
        {
            objBus.anchoredPosition = new Vector2(SizeObj * CountCurrent, objBus.anchoredPosition.y);
        }
    }
   
}
