using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    void Start()
    {
        var btn = gameObject.GetComponent<Button>();
        if(btn != null)
        {
            btn.onClick.AddListener(onClickButton);
        }
    }

    void onClickButton()
    {
        Audio.Play(ScStatic.SFX_BUTTONSOUND);
        var scaleBegin = transform.localScale;
        transform.DOScale(scaleBegin + Vector3.one * 0.1f, 0.05f).SetEase(Ease.InOutSine).OnComplete(() => {
            transform.DOScale(scaleBegin , 0.05f).SetEase(Ease.OutBack).OnComplete(() => {

            });
        });
    }    
}
