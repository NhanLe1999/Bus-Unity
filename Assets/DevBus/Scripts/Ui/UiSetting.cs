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

    void Start()
    {
        OnEnableBtn(TypeBtnSetting.MUSIC, HelperManager.DataPlayer.isPlayMusic);
        OnEnableBtn(TypeBtnSetting.SOUND, HelperManager.DataPlayer.isPlaySound);
        OnEnableBtn(TypeBtnSetting.VIBRATION, HelperManager.DataPlayer.isVbration);
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

}
