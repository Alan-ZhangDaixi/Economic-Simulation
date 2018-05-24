using UnityEngine;
using System.Collections.Generic;

public class EconomicSystemModel : MonoBehaviour
{
    public EconomicSystemData ecoSysdata { get; private set; }
    public Dictionary<int, EcoPlayerGroupModel> ecoPlayerGroupModelDic;
    public Dictionary<int, TargetPlaceModel> targetPlaceModelDic;

    public GameObject placePrefab { get; private set; }
    public GameObject ecoPlayerGroupPrefab { get; private set; }
    public GameObject placeParent { get; private set; }
    public GameObject ecoPlayerGroupParent { get; private set; }
    public GameObject ecoPlayerPrefab { get; private set; }

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

    void Init(EconomicSystemData data, GameObject placePrefab, GameObject ecoPlayerGroupPrefab, GameObject ecoPlayerPrefab)
    {
        ecoSysdata = data;
        this.placePrefab = placePrefab;
        this.ecoPlayerGroupPrefab = ecoPlayerGroupPrefab;
        this.ecoPlayerPrefab = ecoPlayerPrefab;

        ecoPlayerGroupModelDic = new Dictionary<int, EcoPlayerGroupModel>();
        targetPlaceModelDic = new Dictionary<int, TargetPlaceModel>();

        placeParent = new GameObject("placeParent");
        placeParent.transform.parent = transform;
        placeParent.transform.position = Vector3.zero;
        placeParent.transform.eulerAngles = Vector3.zero;

        ecoPlayerGroupParent = new GameObject("ecoPlayerGroupParent");
        ecoPlayerGroupParent.transform.parent = transform;
        ecoPlayerGroupParent.transform.position = Vector3.zero;
        ecoPlayerGroupParent.transform.eulerAngles = Vector3.zero;      

        foreach (KeyValuePair<int, EcoPlayerGroupData> i in ecoSysdata.groupsDicById)
            AddEcoPlayerGroupModelByData(i.Value);

        foreach (KeyValuePair<int, TargetPlaceData> i in ecoSysdata.placesDicById)
            AddPlaceModelByData(i.Value);
    }

    #endregion base functions

    #region functions

    public int AddPlaceModelByData(TargetPlaceData data)
    {
        if (data.type == TargetPlaceType.City)
        {
            GameObject model = GameObject.Instantiate(placePrefab);
            model.transform.parent = placeParent.transform;
            model.transform.position = data.rect.center;
            model.transform.eulerAngles = Vector3.zero;
            CityModel cityModel = model.AddComponent<CityModel>();
            cityModel.Init(this, data);
            targetPlaceModelDic[data.id] = cityModel;
        }

        return data.id;
    }

    public int AddEcoPlayerGroupModelByData(EcoPlayerGroupData data)
    {
        GameObject model = GameObject.Instantiate(ecoPlayerGroupPrefab);
        model.transform.parent = ecoPlayerGroupParent.transform;
        model.transform.position = Vector3.zero;
        model.transform.eulerAngles = Vector3.zero;
        EcoPlayerGroupModel groupModel = model.AddComponent<EcoPlayerGroupModel>();
        groupModel.Init(this, data, ecoPlayerPrefab);
        ecoPlayerGroupModelDic[data.groupId] = groupModel;
        return data.groupId;
    }

    #endregion functions
}

