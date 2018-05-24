using UnityEngine;

public class EconomicSystemSimulator : MonoBehaviour
{
    public EconomicSystemUI economicSystemUI;
    public EconomicSystemData ecoSysData;
    public EconomicSystemLogic ecoSysLogic;
    public EconomicSystemModel ecoSysModel;

    public GameObject placePrefab;
    public GameObject groupPrefab;
    public GameObject ecoPlayerPrefab;

    #region mono functions

    void Start()
    {
        Init();
    }

    #endregion mono functions

    void Init()
    {
        economicSystemUI = gameObject.AddComponent<EconomicSystemUI>();
        ecoSysData = new EconomicSystemData();

        EcoPlayerData tempPlayer = new EcoPlayerData(-1, 10000, 10000, 50, 50, 50, 50, 50, 50, 100, 1);
        ecoSysData.AddGroupData(tempPlayer, 30);

        ecoSysData.AddPlaceData(TargetPlaceType.City);

        ecoSysLogic = new EconomicSystemLogic(ecoSysData);
        ecoSysModel = gameObject.AddComponent<EconomicSystemModel>();
        ecoSysModel.Init(ecoSysData, placePrefab, groupPrefab, ecoPlayerPrefab);
    }
}

