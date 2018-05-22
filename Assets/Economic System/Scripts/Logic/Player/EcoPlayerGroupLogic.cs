using UnityEngine;
using UnityEngine;
using System.Collections.Generic;

public class EcoPlayerGroupLogic
{
    public EcoPlayerGroupLogic(EconomicSystemLogic ecoSysLogic, EcoPlayerGroupData groupData)
    {
        this.ecoSysLogic = ecoSysLogic;
        this.groupData = groupData;


    }

    public EconomicSystemLogic ecoSysLogic { get; private set; }
    public EcoPlayerGroupData groupData { get; private set; }

    EcoPlayerLogic[] ecoPlayerLogics;

    Dictionary<int, EcoPlayerLogic> ecoPlayerLogicsDic;
    
}

