using UnityEngine;
using System.Collections.Generic;

public class EcoPlayerGroupLogic
{
    public EcoPlayerGroupLogic(EconomicSystemLogic ecoSysLogic, EcoPlayerGroupData groupData)
    {
        this.ecoSysLogic = ecoSysLogic;
        this.groupData = groupData;

        ecoPlayerLogics = new EcoPlayerLogic[groupData.playersCnt];
        ecoPlayerLogicsDic = new Dictionary<int, EcoPlayerLogic>();

        for(int i = 0;i< groupData.playersCnt; i++)
        {
            EcoPlayerData ecoPlayerData = groupData.GetPlayerDataById(groupData.startId + i);
            ecoPlayerLogics[i] = new EcoPlayerLogic(ecoSysLogic, this, groupData, ecoPlayerData);
            ecoPlayerLogicsDic[ecoPlayerData.id] = ecoPlayerLogics[i];
        }

        playersCnt = groupData.playersCnt;
    }

    public EconomicSystemLogic ecoSysLogic { get; private set; }
    public EcoPlayerGroupData groupData { get; private set; }

    EcoPlayerLogic[] ecoPlayerLogics;

    Dictionary<int, EcoPlayerLogic> ecoPlayerLogicsDic;

    public int playersCnt { get; private set; }


    public EcoPlayerLogic GetPlayerLogicByIndex(int idx)
    {
        if (idx < 0 || idx >= playersCnt) return null;

        return ecoPlayerLogics[idx];
    }

    public EcoPlayerLogic GetPlayerDataById(int id)
    {
        if (ecoPlayerLogicsDic.ContainsKey(id))
            return ecoPlayerLogicsDic[id];
        return null;
    }

    /// <summary>
    /// 不是真正的删除，可以理解为这个玩家离开了游戏,流失了
    /// </summary>
    public void PlayerLeaveByIndex(int idx)
    {
        groupData.PlayerLeaveByIndex(idx);
    }

    /// <summary>
    /// 不是真正的删除，可以理解为这个玩家离开了游戏,流失了
    /// </summary>
    public void PlayerLeaveById(int id)
    {
        groupData.PlayerLeaveById(id);
    }

}

