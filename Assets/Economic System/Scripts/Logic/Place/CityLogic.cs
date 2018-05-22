using System.Collections.Generic;
using UnityEngine;

public class CityLogic : TargetPlaceLogic
{
    public CityLogic(EconomicSystemLogic ecoSysLogic, TargetPlaceData data)
    {
        this.data = data as CityData;
        this.ecoSysLogic = ecoSysLogic;
    }

    public EconomicSystemLogic ecoSysLogic { get; private set; }
    public CityData data { get; private set; }
}

