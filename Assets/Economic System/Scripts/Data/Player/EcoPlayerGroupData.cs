using UnityEngine;
using System.Collections.Generic;
using System;

public class EcoPlayerGroupData
{
    // constructor
    public EcoPlayerGroupData(int groupId, EcoPlayerData proto, int cnt, int startId)
    {
        this.groupId = groupId;
        protoGroup = new EcoPlayerData(-1, proto);
        playersCnt = cnt;
        ecoPlayers = new EcoPlayerData[cnt];
        ecoPlayersDic = new Dictionary<int, EcoPlayerData>();
        this.startId = startId;

        for (int i = 0; i < playersCnt; i++)
        {
            ecoPlayers[i] = new EcoPlayerData(startId, protoGroup);
            ecoPlayersDic[ecoPlayers[i].id] = ecoPlayers[i];
            startId++;
        }
    }

    public void Free()
    {
        for (int i = 0; i < playersCnt; i++)
        {
            ecoPlayers[i].Free();
        }

        ecoPlayers = null;
        ecoPlayersDic.Clear();
        ecoPlayersDic = null;
    }

    // data

    EcoPlayerData protoGroup; // 备份的一份原型数据，所有该对象里面的所有player数据原型

    EcoPlayerData[] ecoPlayers;

    Dictionary<int, EcoPlayerData> ecoPlayersDic; // 方便外面通过角色id访问数据

    public int groupId { get; private set; }

    public string groupType { get { return protoGroup.type; } }

    public int startId { get; private set; }

    public int playersCnt { get; private set; }

    // functions
    // 该数据结构不考虑之后还会增加的情况，只有get和delete方法

    public EcoPlayerData GetPlayerDataByIndex(int idx)
    {
        if (idx < 0 || idx >= playersCnt) return null;

        return ecoPlayers[idx];
    }

    public EcoPlayerData GetPlayerDataById(int id)
    {
        if (ecoPlayersDic.ContainsKey(id))
            return ecoPlayersDic[id];
        return null;
    }

    /// <summary>
    /// 不是真正的删除，可以理解为这个玩家离开了游戏,流失了
    /// </summary>
    public void PlayerLeaveByIndex(int idx)
    {
        if (idx < 0 || idx >= playersCnt) return;

        ecoPlayers[idx].isAway = true;
    }

    /// <summary>
    /// 不是真正的删除，可以理解为这个玩家离开了游戏,流失了
    /// </summary>
    public void PlayerLeaveById(int id)
    {
        if (!ecoPlayersDic.ContainsKey(id)) return;

        ecoPlayersDic[id].isAway = true;
    }
}

