using UnityEngine;
using System.Collections.Generic;

public class EconomicSystemLogic
{
    public EconomicSystemLogic(EconomicSystemData data)
    {
        ecoSysdata = data;
        ecoPlayerGroupLogicDic = new Dictionary<int, EcoPlayerGroupLogic>();
        targetPlaceLogicDic = new Dictionary<int, TargetPlaceLogic>();

        foreach (KeyValuePair<int, EcoPlayerGroupData> i in ecoSysdata.groupsDicById)
            AddEcoPlayerGroupLogicByData(i.Value);

        foreach (KeyValuePair<int, TargetPlaceData> i in ecoSysdata.placesDicById)
            AddPlaceLogicByData(i.Value);
    }

    public EconomicSystemData ecoSysdata { get; private set; }
    public Dictionary<int, EcoPlayerGroupLogic> ecoPlayerGroupLogicDic;
    public Dictionary<int, TargetPlaceLogic> targetPlaceLogicDic;

    #region functions

    public int AddPlaceLogicByData(TargetPlaceData data)
    {
        if(data.type == TargetPlaceType.City)
        {
            CityLogic logic = new CityLogic(this, data);
            targetPlaceLogicDic[data.id] = logic;
        }

        return data.id;
    }

    public int AddEcoPlayerGroupLogicByData(EcoPlayerGroupData data)
    {
        EcoPlayerGroupLogic logic = new EcoPlayerGroupLogic(this, data);
        ecoPlayerGroupLogicDic[data.groupId] = logic;
        return data.groupId;
    }

    #endregion functions
}

