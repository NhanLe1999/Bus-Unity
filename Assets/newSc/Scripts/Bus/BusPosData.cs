using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public struct BusPosData
{
    public JunkColor color;

    public BusType type;

    public Vector3 position;

    public Quaternion rotation;

    public List<int> nodeIndexList;

    public List<int> backTrackList;

    public int weight;

    public void setColor(JunkColor co)
    {
        this.color = co;
    }
}