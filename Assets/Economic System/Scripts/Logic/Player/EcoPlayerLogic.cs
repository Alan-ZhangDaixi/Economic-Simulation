using UnityEngine;

public class EcoPlayerLogic
{
    public EcoPlayerLogic(EconomicSystemLogic ecoSysLogic, EcoPlayerGroupLogic groupLogic, EcoPlayerGroupData groupData, EcoPlayerData data)
    {
        this.ecoSysLogic = ecoSysLogic;
        this.groupLogic = groupLogic;
        this.groupData = groupData;
        this.data = data;
        targetPos = data.localPos;
    }

    public EconomicSystemLogic ecoSysLogic { get; private set; }

    public EcoPlayerGroupLogic groupLogic { get; private set; }

    public EcoPlayerGroupData groupData { get; private set; }

    public EcoPlayerData data { get; private set; }

    public TargetPlaceLogic targetPlaceLogic { get; private set; }

    public Vector2 targetPos { get; private set; }

    public bool isArrive { get { return (data.localPos - targetPos).sqrMagnitude < 1.0f; } }

    #region base function

    void Update()
    {
        Move2TargetPlace();
    }

    #endregion base function

    public void ArrangeTargetPlace(TargetPlaceLogic place)
    {
        data.targetId = place.baseData.id;
        targetPlaceLogic = place;

        RandomHelper.ResetRandomSeed((data.id * targetPlaceLogic.baseData.id) % (Time.frameCount % 12000));
        Rect placeRect = targetPlaceLogic.baseData.rect;
        Vector2 min = placeRect.min;
        Vector2 max = placeRect.max;
        targetPos = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));

        data.NotifyDataChange();
    }

    public void Move2TargetPlace()
    {
        if (targetPlaceLogic == null) return;

        if (isArrive) return;



        //data.targetId = place.baseData.id;
        //targetPlaceLogic = place;
        //
        //RandomHelper.ResetRandomSeed((data.id * targetPlaceLogic.baseData.id) % (Time.frameCount % 12000));
        //Rect placeRect = targetPlaceLogic.baseData.rect;
        //Vector2 min = placeRect.min;
        //Vector2 max = placeRect.max;
        //targetPos = new Vector2(Random.Range(min.x, max.x), Random.Range(min.y, max.y));
        //
        //data.NotifyDataChange();
    }
}