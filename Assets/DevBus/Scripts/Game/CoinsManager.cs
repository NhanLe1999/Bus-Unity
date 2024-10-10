using System.Collections;
using UnityEngine;
using TMPro;

public class CoinsManager : SingletonMono<CoinsManager>
{
    [SerializeField] TextMeshProUGUI coinTxt;

    private int totalCoins;

    private void Start()
    {
        UpdateCoinTxt();
    }
    public int GetTotalCoins()
    {
        return HelperManager.DataPlayer.TotalCoin;
    }

    public void AddCoins(int amount)
    {
        int coins = GetTotalCoins();
        coins += amount;
        HelperManager.UpdateItemForSkill(TYPE_ITEM.COIN, coins);
        UpdateCoinTxt();
    }
    public void DeductCoins(int amount)
    {
        HelperManager.UpdateItemForSkill(TYPE_ITEM.COIN, -amount);

        UpdateCoinTxt();
    }
    public void UpdateCoinTxt()
    {
        totalCoins = GetTotalCoins();
        coinTxt.text = totalCoins.ToString();
    }
}