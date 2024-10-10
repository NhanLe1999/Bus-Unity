using _Game.Scripts.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "Bus Level", fileName = "Bus Level")]
public class BusLevelSO : ScriptableObject
{
    public static BusLevelSO active;

    public BusMapHardness busMapHardness;

    public List<BusPosData> busPosDatas;

    public List<TunnelDataPack> tunnelDataPacks;

    public int totalMinionNum;

    public AnchorPointData[] anchorPoints;

    public List<int> grayBusIndexes;

    List<int> listIndexColor = new();
    List<JunkColor> listDefaultColor = new();


    public void ShufferData()
    {
        int[] values = (int[])Enum.GetValues(typeof(JunkColor));

        JunkColor[] Colos = (JunkColor[])Enum.GetValues(typeof(JunkColor));

        listIndexColor = values.ToList();
        int n = listIndexColor.Count;
        System.Random rng = new System.Random();

        for (int i = n - 1; i > 0; i--)
        {
            int j = rng.Next(0, i + 1);
            int temp = listIndexColor[i];
            listIndexColor[i] = listIndexColor[j];
            listIndexColor[j] = temp;
        }

    }

    public void LoadLevel()
    {
    }

    public void SaveLevel()
    {
    }
}