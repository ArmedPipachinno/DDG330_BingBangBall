using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ZoneData
{
    public int OrderId;
    public int ScoreValue;
    public GameObject ZoneType;

    public ZoneData(int order, int score, GameObject zone)
    {
        this.OrderId = order;
        this.ScoreValue = score;
        this.ZoneType = zone;
    }
}
