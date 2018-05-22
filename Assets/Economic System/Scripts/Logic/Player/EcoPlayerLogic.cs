public class EcoPlayerLogic
{
    public EcoPlayerLogic(EconomicSystemLogic ecoSysLogic, EcoPlayerData data, EcoPlayerGroupData groupData)
    {
        this.ecoSysLogic = ecoSysLogic;
        this.data = data;
        this.groupData = groupData;
    }

    public EconomicSystemLogic ecoSysLogic { get; private set; }
    public EcoPlayerData data { get; private set; }
    public EcoPlayerGroupData groupData { get; private set; }
}