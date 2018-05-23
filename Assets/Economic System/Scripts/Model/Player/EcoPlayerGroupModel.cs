using UnityEngine;
using System.Collections.Generic;

public class EcoPlayerGroupModel : MonoBehaviour
{
    public EcoPlayerGroupData groupData { get; private set; }

    EcoPlayerModel[] ecoPlayerModels;

    Dictionary<int, EcoPlayerModel> ecoPlayerModelsDic;

    public int playersCnt { get; private set; }

    #region mono functions

    void Start()
    {

    }

    void Update()
    {

    }

    void FixedUpdate()
    {

    }

    void OnDestroy()
    {
        Free();
    }

    #endregion mono functions

    #region base function

    void Init(EcoPlayerGroupData data, GameObject prefab)
    {
        groupData = data;
        ecoPlayerModels = new EcoPlayerModel[groupData.playersCnt];
        ecoPlayerModelsDic = new Dictionary<int, EcoPlayerModel>();

        for (int i = 0; i < groupData.playersCnt; i++)
        {
            EcoPlayerData ecoPlayerData = groupData.GetPlayerDataById(groupData.startId + i);
            GameObject model = GameObject.Instantiate(prefab);
            model.transform.parent = transform;
            model.transform.position = ecoPlayerData.localPos;
            model.transform.eulerAngles = Vector3.zero;
            EcoPlayerModel ecoModel = model.GetComponent<EcoPlayerModel>();
            ecoModel.Init(ecoPlayerData);
            ecoPlayerModels[i] = ecoModel;
            ecoPlayerModelsDic[ecoPlayerData.id] = ecoModel;
        }

        playersCnt = groupData.playersCnt;
        groupData.onDataAwayChange += DataAwayChange;
    }

    void Free()
    {
        if(groupData != null)
            groupData.onDataAwayChange -= DataAwayChange;
    }

    #endregion base function

    #region functions

    public EcoPlayerModel GetPlayerModelByIndex(int idx)
    {
        if (idx < 0 || idx >= playersCnt) return null;

        return ecoPlayerModels[idx];
    }

    public EcoPlayerModel GetPlayerModelById(int id)
    {
        if (ecoPlayerModelsDic.ContainsKey(id))
            return ecoPlayerModelsDic[id];
        return null;
    }

    #endregion functions

    #region action相关

    void DataAwayChange(int id)
    {

    }

    #endregion action相关
}

