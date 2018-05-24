using UnityEngine;

public class EconomicSystemSimulator : MonoBehaviour
{
    public EconomicSystemUI economicSystemUI;
    public EconomicSystemData ecoSysData;
    public EconomicSystemLogic ecoSysLogic;

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
        ecoSysLogic = new EconomicSystemLogic(ecoSysData);
    }
}

