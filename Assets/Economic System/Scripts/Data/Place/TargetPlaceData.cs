using UnityEngine;

public enum TargetPlaceType
{
    City = 0,      // 城镇里面可以进行交易
    Field,         // 可以进行打怪练级，可以获取经验，装备
    Instance,      // 副本
    RestRoom,      // 休息室（玩家疲劳度耗尽之后）
    Battlefield    // 战场（PVP）
}

public abstract class TargetPlaceData
{
    // data

    public int id;

    public TargetPlaceType type;

    public Rect rect;

    public bool isActive;

    public float tiredFac;                   //疲劳度系数，玩家在该区域疲劳度会降低
}

