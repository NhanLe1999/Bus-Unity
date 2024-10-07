using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public enum TypeBtnSetting
{
    SOUND,
    MUSIC,
    VIBRATION
}

[Serializable]
public class DataButtonSetting
{
    public TypeBtnSetting typeBtn;
    public GameObject objOn;
    public GameObject objOff;
}

public class UiSetting : MonoBehaviour
{
    [SerializeField] List<DataButtonSetting> dataButtonSettings = null;
    [SerializeField] Transform trsObjScale = null;

    void Start()
    {
       
    }

    private void OnEnable()
    {
        if(LoadDataGame.Instance != null)
        {
            LoadDataGame.Instance.IsPause = true;
        }

        OnEnableBtn(TypeBtnSetting.MUSIC, HelperManager.DataPlayer.isPlayMusic);
        OnEnableBtn(TypeBtnSetting.SOUND, HelperManager.DataPlayer.isPlaySound);
        OnEnableBtn(TypeBtnSetting.VIBRATION, HelperManager.DataPlayer.isVbration);
        this.StartCoroutine(onPlayAnim());
       
    }

    IEnumerator onPlayAnim()
    {
        yield return new WaitForEndOfFrame();

        trsObjScale.DOScale(Vector3.one, 0.25f).SetEase(Ease.OutBack).OnComplete(() => {
        });
    }

    private void OnEnableBtn(TypeBtnSetting type, bool isEnable)
    {
        foreach (var item in dataButtonSettings)
        {
            if (type.Equals(item.typeBtn))
            {
               // item.objOn?.SetActive(isEnable);
                item.objOff?.SetActive(!isEnable);
                break;
            }
        }
    }

    public void OnClickSound()
    {
        Audio.soundEnabled = !Audio.soundEnabled;
        OnEnableBtn(TypeBtnSetting.SOUND, Audio.soundEnabled);
    }

    public void OnClickMusic()
    {
        Audio.musicEnabled = !Audio.musicEnabled;
        OnEnableBtn(TypeBtnSetting.MUSIC, Audio.musicEnabled);
        if (Audio.musicEnabled)
        {
            Audio.ResumeBackgroundMusic();
        }
        else
        {
            Audio.PauseBackgroundMusic();
        }
    }

    public void OnClickVbration()
    {
        HelperManager.DataPlayer.isVbration = !HelperManager.DataPlayer.isVbration;
        OnEnableBtn(TypeBtnSetting.VIBRATION, HelperManager.DataPlayer.isVbration);
    }

    public void OnHomeClick()
    {
        HelperManager.OnLoadScene(ScStatic.HOME_SCENE);
    }

    public void OnRestartClick()
    {
        HelperManager.OnLoadScene(ScStatic.GAME_SCENE);
    }

    public void OnClose()
    {
        trsObjScale.DOScale(Vector3.zero, 0.25f).OnComplete(() => {
            gameObject.SetActive(false);
            LoadDataGame.Instance.IsPause = false;
        });
    }    
}
