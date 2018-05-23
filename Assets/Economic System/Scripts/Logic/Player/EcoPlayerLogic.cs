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

    public bool isArrive { get { return (data.localPos - targetPos).sqrMagnitude < data.moveSpeed * timeScale; } }

    public float timeScale = 1.0f;

    public const float TimeCost = 0.02f; 

    #region base function

    /// <summary>
    /// 由simulator或者外界调用
    /// </summary>
    public void FixedUpdate()
    {
        Move2TargetPlace();
        CostTiredInPlace();
        RecoverTired();
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

        if (isArrive)
        {
            data.localPos = targetPos;
        }
        else
        {
            Vector2 dir = (targetPos - data.localPos).normalized;
            data.localPos += dir * data.moveSpeed * timeScale;
        }    
    }

    public void CostTiredInPlace()
    {
        if (targetPlaceLogic == null) return;

        if (!data.isActive) return;

        data.tired -= targetPlaceLogic.baseData.tiredFac * TimeCost * timeScale;

        if(data.tired < 0.0f)
        {
            data.tired = 0.0f;
            data.isActive = false;
        }
    }

    public void RecoverTired()
    {
        if (data.isActive) return;

        data.tired += data.recoverTiredFac * TimeCost * timeScale;

        if(data.tired > 100.0f)
        {
            data.tired = 100.0f;
            data.isActive = true;
        }
    }
}