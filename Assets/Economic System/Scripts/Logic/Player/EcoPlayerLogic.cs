public class EcoPlayerLogic
{
    public EcoPlayerLogic(EconomicSystemLogic ecoSysLogic, EcoPlayerGroupLogic groupLogic, EcoPlayerGroupData groupData, EcoPlayerData data)
    {
        this.ecoSysLogic = ecoSysLogic;
        this.groupLogic = groupLogic;
        this.groupData = groupData;
        this.data = data;
    }

    public EconomicSystemLogic ecoSysLogic { get; private set; }
    public EcoPlayerGroupLogic groupLogic { get; private set; }
    public EcoPlayerGroupData groupData { get; private set; }
    public EcoPlayerData data { get; private set; }
}