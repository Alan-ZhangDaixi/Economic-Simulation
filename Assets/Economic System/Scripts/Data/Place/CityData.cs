using UnityEngine;

public class CityData : TargetPlaceData
{
    // constructor
    public CityData(int id, TargetPlaceType type)
    {
        this.id = id;
        this.type = type;
        isActive = true;
    }

    // data 

    public float exchangeRate;             //游戏币换法币的汇率，汇率是波动的，由模拟的玩家动态平衡
}

