using _Game.Scripts.Bus;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct TunnelDataPack
{
    public List<TunnelBusData> datas;

    public Vector3 position;

    public Quaternion rotation;

    public int lockBusIndex;

    public List<int> blockBusIndexList;
}