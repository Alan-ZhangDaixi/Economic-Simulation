using UnityEngine;
using System;

/// <summary>
/// 为了方便，该数据既可以作为设计数据，又可以作为实时数据
/// </summary>
public class EcoPlayerData
{
    // Construct
    public EcoPlayerData(int id, long money, long realMoney, byte greed, byte realGreed, byte vanity, byte chanllenge, byte constancy, byte freshness, float tired)
    {
        this.id = id;
        isAway = false;

        achievability = 50.0f;
        this.tired = tired;

        roleLevel = 1;
        roleExp = 0;
        roleAbility = 1;
        equipmentLevel = 0;
        appearance = 0;

        targetId = 0;
        localPos = Vector2.zero;
        moveSpeed = 1.0f;

        this.money = money;
        this.realMoney = realMoney;

        this.greed = greed;
        this.realGreed = realGreed;
        this.vanity = vanity;
        this.chanllenge = chanllenge;
        this.constancy = constancy;
        this.freshness = freshness;
    }

    public EcoPlayerData(int id, EcoPlayerData clone)
    {
        this.id = id;
        isAway = false;

        achievability = 50.0f;

        roleLevel = 1;
        roleExp = 0;
        roleAbility = 1;
        equipmentLevel = 0;
        appearance = 0;

        targetId = 0;
        localPos = Vector2.zero;
        moveSpeed = 1.0f;

        tired = clone.tired;
        money = clone.money;
        realMoney = clone.realMoney;
        greed = clone.greed;
        realGreed = clone.realGreed;
        vanity = clone.vanity;
        chanllenge = clone.chanllenge;
        constancy = clone.constancy;
        freshness = clone.freshness;
    }

    public void Free()
    {

    }

    // Data
        
    //所有参数范围为0.0f-100.0f

    public float achievability;        //玩家的成就感，成就感为0，玩家就会流失 (满足度通过玩家参与游戏里面不同的内容，根据玩家的基础属性，来进行提升和降低)

    public float tired;               //玩家的疲劳度（人不可能天天24小时耍游戏）

    #region 物质        

    //所有参数范围为0-100，定义范围为向下包含
    //0-20 Low 20-40 LowMedium 40-60 Medium 60-80 MediumHigh 80-100 High      

    public float money;               //玩家当前游戏币数量
                                      
    public float realMoney;           //玩家实际现实法币数量

    #endregion 物质

    #region 玩家特性

    //所有参数范围为0-100，定义范围为向下包含
    //0-20 Low 20-40 LowMedium 40-60 Medium 60-80 MediumHigh 80-100 High 

    public byte greed;               //玩家对游戏币的贪婪程度（影响玩家对于货币的增减所获得的快感）
                                     
    public byte realGreed;           //玩家对法币的贪婪程度
                                     
    public byte vanity;              //玩家虚荣心（影响玩家花费法币的欲望）
                                     
    public byte chanllenge;          //玩家挑战难度任务和活动的欲望
                                     
    public byte constancy;           //玩家的持久力(玩家是否可以一直做枯燥乏味的事情)
                                     
    public byte freshness;           //玩家的新鲜感（根据任务活动的有趣程度，玩家如果新鲜感很高，那么可能去参加不那么有趣的活动）

    #endregion 玩家特性

    #region 玩家角色属性

    public int roleLevel;            //角色等级
                                     
    public int roleExp;              //角色经验
                                     
    public int roleAbility;          //角色能力（这个能力主要只等级提升过程中和等级满级之后，除装备外的对角色的提升）
                                     
    public int equipmentLevel;       //装备等级

    public int equipmentDurability;  //装备的耐久度

    public int appearance;           //角色外观

    #endregion 玩家角色属性

    #region 模拟所需基础数据

    public int id;                   //该数据id，不可重复
                                     
    public int targetId;            //target可以理解成玩家当前所想要去的场所(比如交易所，练级点)
                                     
    public Vector2 localPos;         //当前游戏角色在模拟区域的局部坐标

    public float moveSpeed;

    public bool isAway;                //当前玩家是否流失

    #endregion 模拟所需基础数据

    // Properties
    public string type
    {
        get
        {
            string s_money = ParamsRankStr(money) + " money";
            string s_realMoney = ParamsRankStr(realMoney) + " real money";

            string s_greed = ParamsRankStr(greed) + " greed";
            string s_realGreed = ParamsRankStr(realGreed) + " real greed";
            string s_vanity = ParamsRankStr(vanity) + " vanity";
            string s_chanllenge = ParamsRankStr(chanllenge) + " chanllenge";
            string s_durability = ParamsRankStr(constancy) + " durability";
            string s_freshness = ParamsRankStr(freshness) + " freshness";

            return s_money + " " + s_realMoney + " " +
                   s_greed + " " + s_realGreed + " " +
                   s_vanity + " " + s_chanllenge + " " +
                   s_durability + " " + s_freshness + " EcoPlayer";
        }
    }

    // Functions
    public string ParamsRankStr(byte param)
    {
        if (param < 20)
            return "Low";
        if (param < 40)
            return "LowMedium";
        if (param < 60)
            return "Medium";
        if (param < 80)
            return "MediumHigh";
        if (param <= 100)
            return "High";

        return "data error";
    }

    public string ParamsRankStr(float param)
    {
        if (param < 20.0f)
            return "Low";
        if (param < 40.0f)
            return "LowMedium";
        if (param < 60.0f)
            return "Medium";
        if (param < 80.0f)
            return "MediumHigh";
        if (param <= 100.0f)
            return "High";

        return "data error";
    }

    public int ParamsRank(byte param)
    {
        if (param < 20)
            return 0;
        if (param < 40)
            return 1;
        if (param < 60)
            return 2;
        if (param < 80)
            return 3;
        if (param <= 100)
            return 4;

        return -1;
    }

    public int ParamsRank(float param)
    {
        if (param < 20.0f)
            return 0;
        if (param < 40.0f)
            return 1;
        if (param < 60.0f)
            return 2;
        if (param < 80.0f)
            return 3;
        if (param <= 100.0f)
            return 4;

        return -1;
    }

    public event Action onDataChange;
    public void NotifyDataChange()
    {
        if (onDataChange != null)
            onDataChange();
    }
}
