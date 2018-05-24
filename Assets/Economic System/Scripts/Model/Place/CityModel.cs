using UnityEngine;

public class CityModel : TargetPlaceModel
{
    public EconomicSystemModel ecoSysModel { get; private set; }
    public CityData data { get; private set; }

    #region mono functions

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    private void OnDestroy()
    {
        
    }

    #endregion mono functions

    #region base functions

    public void Init(EconomicSystemModel ecoSysModel, TargetPlaceData data)
    {
        baseData = data;
        this.data = data as CityData;
        this.ecoSysModel = ecoSysModel;
    }

    #endregion base functions

    #region functions



    #endregion functions
}

