using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

[System.Serializable]
public class DataNumSkillGame
{
    public int numCountUse;
    public TYPE_ITEM typeSkill;
}

[System.Serializable]
public class DataPlayer
{
    public int NumLevel = 1;
    public bool isPlaySound = true;
    public bool isPlayMusic = true;
    public bool isVbration = true;

    public bool isWin5Level = false;

    public int NumTotalSpin = 0;
    public int TotalCoin = 0;

    public int numDayLogin = 0;
    public int numWinLevel = 0;

    public string stateLogin = ScStatic.STATE_LOGIN_NEW;


    public List<DataNumSkillGame> DataNumSkillGame = new();
}
